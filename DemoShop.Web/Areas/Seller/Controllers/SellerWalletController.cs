using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.SellerWallet;
using DemoShop.Web.PresentationExtensions;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.Seller.Controllers
{
    public class SellerWalletController : SellerBaseController
    {
        #region constructor

        private readonly ISellerWalletService _sellerWalletService;
        private readonly ISellerService _sellerService;

        public SellerWalletController(ISellerWalletService sellerWalletService, ISellerService sellerService)
        {
            _sellerWalletService = sellerWalletService;
            _sellerService = sellerService;
        }

        #endregion

        #region index

        [HttpGet("seller-wallet")]
        public async Task<IActionResult> Index(FilterSellerWalletDTO filter)
        {
            filter.TakeEntity = 5;
            var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());
            if (seller == null) return NotFound();
            filter.SellerId = seller.Id;
            return View(await _sellerWalletService.FilterSellerWallet(filter));
        }

        #endregion
    }
}
