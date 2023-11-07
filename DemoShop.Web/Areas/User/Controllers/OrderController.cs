using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Orders;
using DemoShop.Web.Http;
using DemoShop.Web.PresentationExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.User.Controllers
{
    public class OrderController : UserBaseController
    {
        #region constructor

        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        #endregion

        #region add product to open order

        [AllowAnonymous]
        [HttpPost("add-product-to-order")]
        public async Task<IActionResult> AddProductToOrder(AddProductToOrderDTO order)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    await _orderService.AddProductToOpenOrder(User.GetUserId(), order);
                    return JsonResponseStatus.SendStatus(
                        JsonResponseStatusType.Success,
                        "محصول مورد نظر با موفقیت ثبت شد",
                        null);
                }
                else
                {
                    return JsonResponseStatus.SendStatus(
                        JsonResponseStatusType.Danger,
                        "برای ثبت محصول در سبد خرید ابتدا باید وارد سایت شوید",
                        null);
                }
            }

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger,
                "در ثبت اطلاعات خطایی رخ داد", null);
        }

        #endregion

        #region open order

        [HttpGet("open-order")]
        public async Task<IActionResult> UserOpenOrder()
        {
            var openOrder = await _orderService.GetUserOpenOrderDetail(User.GetUserId());
            return View(openOrder);
        }

        #endregion

        #region open order partial

        [HttpGet("change-detail-count/{detailId}/{count}")]
        public async Task<IActionResult> ChangeDetailCount(long detailId, int count)
        {
            await Task.Delay(2000);
            await _orderService.ChangeOrderDetailCount(detailId, User.GetUserId(), count);
            var openOrder = await _orderService.GetUserOpenOrderDetail(User.GetUserId());
            return PartialView(openOrder);
        }

        #endregion

        #region remove product from order

        [HttpGet("remove-order-item/{detailId}")]
        public async Task<IActionResult> RemoveProductFromOrder(long detailId)
        {
            var res = await _orderService.RemoveOrderDetail(detailId, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "محصول مورد نظر با موفقیت از سبد خرید حذف شد";
                return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success, "محصول مورد نظر با موفقیت از سبد خرید حذف شد", null);
            }

            TempData[ErrorMessage] = "محصول مورد نظر در سبد خرید شما یافت نشد";
            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger, "محصول مورد نظر در سبد خرید شما یافت نشد", null);
        }

        #endregion
    }
}
