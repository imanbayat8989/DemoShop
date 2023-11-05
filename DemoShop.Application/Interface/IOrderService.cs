using DemoShop.DataLayer.DTO.Orders;
using DemoShop.DataLayer.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Interface
{
    public interface IOrderService : IAsyncDisposable
    {
        #region order

        Task<long> AddOrderForUser(long userId);
        Task<Order> GetUserLatestOpenOrder(long userId);

        #endregion

        #region order detail

        Task AddProductToOpenOrder(long userId, AddProductToOrderDTO order);

        #endregion
    }
}
