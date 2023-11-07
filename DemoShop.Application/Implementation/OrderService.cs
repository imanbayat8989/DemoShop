using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Orders;
using DemoShop.DataLayer.Entities.ProductOrder;
using DemoShop.DataLayer.Entities.Wallet;
using DemoShop.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Implementation
{
    public class OrderService : IOrderService
    {
        #region constructor

        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        private readonly ISellerWalletService _sellerWalletService;

        public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<OrderDetail> orderDetailRepository, ISellerWalletService sellerWalletService)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _sellerWalletService = sellerWalletService;
        }

        #endregion

        #region order

        public async Task<long> AddOrderForUser(long userId)
        {
            var order = new Order { UserId = userId };

            await _orderRepository.AddEntity(order);

            await _orderRepository.SaveChanges();

            return order.Id;
        }

        public async Task<Order> GetUserLatestOpenOrder(long userId)
        {
            if (!await _orderRepository.GetQuery().AnyAsync(s => s.UserId == userId && !s.IsPaid))
                await AddOrderForUser(userId);

            var userOpenOrder = await _orderRepository.GetQuery()
                .Include(s => s.OrderDetails)
                .ThenInclude(s => s.ProductColor)
                .Include(s => s.OrderDetails)
                .ThenInclude(s => s.Product)
                .ThenInclude(s => s.ProductDiscounts)
                .SingleOrDefaultAsync(s => s.UserId == userId && !s.IsPaid);

            return userOpenOrder;
        }

        public async Task<int> GetTotalOrderPriceForPayment(long userId)
        {
            var userOpenOrder = await GetUserLatestOpenOrder(userId);
            int totalPrice = 0;

            foreach (var detail in userOpenOrder.OrderDetails)
            {
                var oneProductPrice = detail.ProductColor != null
                    ? detail.Product.Price + detail.ProductColor.Price
                    : detail.Product.Price;

                totalPrice += detail.Count * oneProductPrice;
            }

            return totalPrice;
        }

        public async Task PayOrderProductPriceToSeller(long userId)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);

            foreach (var detail in openOrder.OrderDetails)
            {
                var productPrice = detail.Product.Price;
                var productColorPrice = detail.ProductColor?.Price ?? 0;
                var discount = 0;
                var totalPrice = detail.Count * (productPrice + productColorPrice) - discount;

                await _sellerWalletService.AddWallet(new SellerWallet
                {
                    SellerId = detail.Product.SellerId,
                    Price = (int)Math.Ceiling(totalPrice * detail.Product.SiteProfit / (double)100),
                    TransactionType = TransactionType.Deposit,
                    Description = $"پرداخت مبلغ {totalPrice} تومان جهت فروش {detail.Product.Title} به تعداد {detail.Count} عدد با سهم تهیین شده ی {100 - detail.Product.SiteProfit} درصد"
                });

                detail.ProductPrice = totalPrice;
                detail.ProductColorPrice = productColorPrice;
                _orderDetailRepository.EditEntity(detail);
            }

            openOrder.IsPaid = true;
            // todo: set description and tracing code in order
            _orderRepository.EditEntity(openOrder);
            await _orderRepository.SaveChanges();
        }

        public async Task ChangeOrderDetailCount(long detailId, long userId, int count)
        {
            var userOpenOrder = await GetUserLatestOpenOrder(userId);
            var detail = userOpenOrder.OrderDetails.SingleOrDefault(s => s.Id == detailId);
            if (detail != null)
            {
                if (count > 0)
                {
                    detail.Count = count;
                }
                else
                {
                    _orderDetailRepository.DeleteEntity(detail);
                }
                await _orderDetailRepository.SaveChanges();
            }
        }

        #endregion

        #region order detail

        public async Task AddProductToOpenOrder(long userId, AddProductToOrderDTO order)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);

            var similarOrder = openOrder.OrderDetails.SingleOrDefault(s =>
                s.ProductId == order.ProductId && s.ProductColorId == order.ProductColorId);

            if (similarOrder == null)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = openOrder.Id,
                    ProductId = order.ProductId,
                    ProductColorId = order.ProductColorId,
                    Count = order.Count
                };

                await _orderDetailRepository.AddEntity(orderDetail);
                await _orderDetailRepository.SaveChanges();
            }
            else
            {
                similarOrder.Count += order.Count;
                await _orderDetailRepository.SaveChanges();
            }
        }

        public async Task<UserOpenOrderDTO> GetUserOpenOrderDetail(long userId)
        {
            var userOpenOrder = await GetUserLatestOpenOrder(userId);

            return new UserOpenOrderDTO
            {
                UserId = userId,
                Description = userOpenOrder.Description,
                Details = userOpenOrder.OrderDetails
                    .Where(s => !s.IsDeleted)
                    .Select(s => new UserOpenOrderDetailItemDTO
                    {
                        DetailId = s.Id,
                        Count = s.Count,
                        ColorName = s.ProductColor?.ColorName,
                        ProductColorId = s.ProductColorId,
                        ProductColorPrice = s.ProductColor?.Price ?? 0,
                        ProductId = s.ProductId,
                        ProductPrice = s.Product.Price,
                        ProductTitle = s.Product.Title,
                        ProductImageName = s.Product.ImageName,
                        DiscountPercentage = s.Product.ProductDiscounts
                        .OrderByDescending(a => a.CreateDate)
                        .FirstOrDefault(a => a.ExpireDate > DateTime.Now)?.Percentage
                    }).ToList()
            };
        }

        public async Task<bool> RemoveOrderDetail(long detailId, long userId)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);
            var orderDetail = openOrder.OrderDetails.SingleOrDefault(s => s.Id == detailId);
            if (orderDetail == null) return false;

            _orderDetailRepository.DeleteEntity(orderDetail);
            await _orderDetailRepository.SaveChanges();

            return true;
        }

        #endregion

        #region dispose

        public async ValueTask DisposeAsync()
        {
            await _orderRepository.DisposeAsync();
            await _orderDetailRepository.DisposeAsync();
        }

        #endregion
    }
}
