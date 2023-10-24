using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.User.Controllers
{
    public class AccountController : UserBaseController
    {
        #region Constructor
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region user Dashboard
        [HttpGet("")]
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }

        #endregion
    }
}
