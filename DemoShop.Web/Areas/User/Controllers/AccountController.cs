using DemoShop.DataLayer.DTO.Account;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.User.Controllers
{
    public class AccountController : UserBaseController
    {
        #region Constructor
        
        #endregion

        #region user Dashboard

        [HttpGet("change-password")]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }


        [HttpPost("change-password"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO passwordDto)
        {
            return View();
        }

        #endregion
    }
}
