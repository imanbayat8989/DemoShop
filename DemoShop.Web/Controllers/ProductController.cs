using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Products;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Controllers
{
    public class ProductController : SiteBaseController
    {
        #region constructor

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region filter products

        [HttpGet("products")]
        public async Task<IActionResult> FilterProducts(FilterProductDTO filter)
        {
            var products = await _productService.FilterProducts(filter);

            return View(products);
        }

        #endregion
    }
}
