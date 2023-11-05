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
    }
}
