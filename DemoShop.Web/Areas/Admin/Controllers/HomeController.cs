using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        #region index

        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}
