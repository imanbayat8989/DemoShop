using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.ViewComponents
{
	public class SiteHeaderViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("SiteHeader");
		}
	}

	public class SiteFooterViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("SiteFooter");
		}


	}
}
