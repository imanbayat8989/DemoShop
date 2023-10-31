using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Products;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.Admin.Controllers
{
    public class ProductsController : AdminBaseController
    {
        #region constructor

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region filter products

        public async Task<IActionResult> Index(FilterProductDTO filter)
        {
            return View(await _productService.FilterProducts(filter));
        }

        #endregion
    }
}
