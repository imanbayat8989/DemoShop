using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.User.Controllers
{
    public class HomeController : UserBaseController
    {
        #region constructor



        #endregion

        #region user dashboard

        [HttpGet("")]
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }

        #endregion
    }
}
