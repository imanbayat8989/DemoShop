using DemoShop.Application.Interface;
using DemoShop.Web.PresentationExtensions;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.ViewComponents
{
    #region site header

    public class SiteHeaderViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public SiteHeaderViewComponent(ISiteService siteService, IUserService userService, IProductService productService)
        {
            _siteService = siteService;
            _userService = userService;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.siteSetting = await _siteService.GetDefaultSiteSetting();
            ViewBag.user = await _userService.GetUserByMobile(User.Identity.Name);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.user = await _userService.GetUserByMobile(User.Identity.Name);
            }

            ViewBag.ProductCategories = await _productService.GetAllActiveProductCategories();

            return View("SiteHeader");
        }
    }

    #endregion

    #region site footer

    public class SiteFooterViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public SiteFooterViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.siteSetting = await _siteService.GetDefaultSiteSetting();

            return View("SiteFooter");
        }
    }

    #endregion

    #region home sliders

    public class HomeSliderViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public HomeSliderViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _siteService.GetAllActiveSliders();
            return View("HomeSlider", sliders);
        }
    }

    #endregion

    #region user order

    public class UserOrderViewComponent : ViewComponent
    {
        private readonly IOrderService _orderService;

        public UserOrderViewComponent(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var openOrder = await _orderService.GetUserLatestOpenOrder(User.GetUserId());
            return View("UserOrder", openOrder);
        }
    }

    #endregion
}
