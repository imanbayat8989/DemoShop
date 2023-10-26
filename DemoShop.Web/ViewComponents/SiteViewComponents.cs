using DemoShop.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.ViewComponents
{
    #region Site Header
    public class SiteHeaderViewComponent : ViewComponent
	{
		private readonly ISiteService _siteService;
        private readonly IUserService _userService;

        public SiteHeaderViewComponent(ISiteService siteService, IUserService userService)
        {
            _siteService = siteService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            ViewBag.siteSetting = await _siteService.GetDefaultSiteSettings();
            ViewBag.user = await _userService.GetUserByMobile(User.Identity.Name);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.user = await _userService.GetUserByMobile(User.Identity.Name);
            }

            return View("SiteHeader");
        }
	}
    #endregion

    #region Site Footer
    public class SiteFooterViewComponent : ViewComponent
	{
		private readonly ISiteService _siteService;

		public SiteFooterViewComponent(ISiteService siteService)
		{
			_siteService = siteService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			ViewBag.SiteSetting = await _siteService.GetDefaultSiteSettings();
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
}
