using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Seller;
using DemoShop.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.Admin.Controllers
{
    public class SellerController : AdminBaseController
    {
        #region constructor

        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        #endregion

        #region seller requests

        public async Task<IActionResult> SellerRequests(FilterSellerDTO filter)
        {
            return View(await _sellerService.FilterSellers(filter));
        }

        #endregion

        #region accept seller request

        public async Task<IActionResult> AcceptSellerRequest(long requestId)
        {
            var result = await _sellerService.AcceptSellerRequest(requestId);

            if (result)
            {
                return JsonResponseStatus.SendStatus(
                    JsonResponseStatusType.Success,
                    "درخواست مورد نظر با موفقیت تایید شد",
                    null);
            }

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger,
                "اطلاعاتی با این مشخصات یافت نشد", null);
        }

        #endregion
    }
}
