using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.Seller.ViewComponents
{
    public class SellerSidebarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SellerSidebar");
        }
    }
}
