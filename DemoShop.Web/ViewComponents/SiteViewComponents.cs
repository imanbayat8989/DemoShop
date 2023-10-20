using DemoShop.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.ViewComponents
{
	public class SiteHeaderViewComponent : ViewComponent
	{
		private readonly ISiteService _siteService;

        public SiteHeaderViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			ViewBag.SiteSetting = await _siteService.GetDefaultSiteSettings();

			return View("SiteHeader");
		}
	}

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
}
