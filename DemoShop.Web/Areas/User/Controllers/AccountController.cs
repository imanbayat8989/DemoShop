using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Account;
using DemoShop.Web.PresentationExtensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Areas.User.Controllers
{
    public class AccountController : UserBaseController
    {
        #region Constructor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


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
            if(ModelState.IsValid)
            {
                var res = await _userService.ChangeUserPassword(passwordDto, User.GetUserId());
                if (res)
                {
                    TempData[SuccessMessage] = "کلمه ی عبور شما تغییر یافت";
                    TempData[InfoMessage] = "لطفا جهت تکمیل فرایند تغییر کلمه ی عبور ، مجددا وارد سایت شوید";
                    await HttpContext.SignOutAsync();
                    return RedirectToAction("Login", "Account", new { area = "" });
                }
                else
                {
                    TempData[ErrorMessage] = "لطفا از کلمه ی عبور جدیدی استفاده کنید";
                    ModelState.AddModelError("NewPassword", "لطفا از کلمه ی عبور جدیدی استفاده کنید");
                }

            }

            return View(passwordDto);
        }

        #endregion
    }
}
