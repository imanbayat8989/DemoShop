using DemoShop.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.Seller.Controllers
{
    public class ProductController : SellerBaseController
    {
        #region constructor

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

     
    }
}
