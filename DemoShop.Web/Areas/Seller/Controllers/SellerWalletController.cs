using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.SellerWallet;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.Seller.Controllers
{
    public class SellerWalletController : SellerBaseController
    {
        #region constructor

        private readonly ISellerWalletService _sellerWalletService;

        public SellerWalletController(ISellerWalletService sellerWalletService)
        {
            _sellerWalletService = sellerWalletService;
        }

        #endregion

        #region index

        [HttpGet("seller-wallet")]
        public async Task<IActionResult> Index(FilterSellerWalletDTO filter)
        {
            filter.TakeEntity = 5;
            return View(await _sellerWalletService.FilterSellerWallet(filter));
        }

        #endregion
    }
}
