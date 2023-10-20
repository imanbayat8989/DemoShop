using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using GoogleReCaptcha.V3.Interface;

namespace DemoShop.Web.Controllers
{
	public class AccountController : SiteBaseController
	{
		#region Constructor
		private readonly IUserService _userService;
		private readonly ICaptchaValidator _captchaValidator;

        public AccountController(IUserService userService, ICaptchaValidator captchaValidator)
        {
            _userService = userService;
            _captchaValidator = captchaValidator;
        }



        #endregion

        #region Register

        [HttpGet("register")]
		public IActionResult Register()
		{
			if (User.Identity.IsAuthenticated)
			{
				return Redirect("/");
			}
			return View();
		}

		[HttpPost("register"), ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterUserDTO register)
		{
            if (!await _captchaValidator.IsCaptchaPassedAsync(register.Captcha))
            {
                TempData[ErrorMessage] = "کد امنیتی شما تایید نشد";
                return View(register);
            }

            if (ModelState.IsValid)
			{
				var res = await _userService.RegisterUser(register);
				switch (res)
				{
					case RegisterUserResult.MobileExists:
						TempData[ErrorMessage] = "تلفن همراه وارد شده تکراری است";
						ModelState.AddModelError("Mobile", "تلفن همراه وارد شده تکراری است");
						break;
					case RegisterUserResult.Success:
						TempData[SuccessMessage] = "ثبت نام شما با موفقیت انجام شد";
						TempData[InfoMessage] = "کد تایید تلفن همراه برای شما ارسال شد";
						return RedirectToAction("login");
					case RegisterUserResult.Error:
						TempData[ErrorMessage] = "با خطا مواجه شدید";
						ModelState.AddModelError("", "با خطا مواجه شدید");
						break;
				}
			}
			return View(register);
		}

		#endregion

		#region Login

		[HttpGet("login")]
		public IActionResult Login()
		{
			if (User.Identity.IsAuthenticated)
			{
				return Redirect("/");
			}
			return View();
		}

		[HttpPost("login"), ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginUserDTO login)
		{
			if(!await _captchaValidator.IsCaptchaPassedAsync(login.Captcha))
			{
				TempData[ErrorMessage] = "کد امنیتی شما تایید نشد";
				return View();
			}

			if (ModelState.IsValid)
			{
				var res = await _userService.GetUserForLogin(login);
				switch (res)
				{
					case LoginUserResult.NotFound:
						TempData[ErrorMessage] = "کاربر مورد نظر یافت نشد";
						break;
					case LoginUserResult.NotActiveted:
						TempData[WarningMessage] = "حساب کاربری شما فعال نشده است";
						break;
					case LoginUserResult.Success:

						var user = await _userService.GetUserByMobile(login.Mobile);

						var claims = new List<Claim>
						{
							new Claim(ClaimTypes.Name,user.Mobile),
							new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
						};

						var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
						var principal = new ClaimsPrincipal(identity);
						var properties = new AuthenticationProperties
						{
							IsPersistent = login.RememberMe
						};

						await HttpContext.SignInAsync(principal, properties);

						TempData[SuccessMessage] = "عملیات ورود با موفقیت انجام شد";
						return Redirect("/");
				}
			}


			return View(login);
		}

		#endregion

		#region Forgot Password

		[HttpGet("forgot-password")]
		public IActionResult ForgotPassword()
		{
			return View();
		}
		[HttpPost("forgot-password"), ValidateAntiForgeryToken]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPassword)
		{
            if (!await _captchaValidator.IsCaptchaPassedAsync(forgotPassword.Captcha))
            {
                TempData[ErrorMessage] = "کد امنیتی شما تایید نشد";
                return View(forgotPassword);
            }
			if(ModelState.IsValid)
			{
				var result = await _userService.RecoverUserPassword(forgotPassword);
                switch (result)
                {
                    case ForgotPasswordResult.Success:
						TempData[SuccessMessage] = "کلمه عبور جدید برای شما ارسال شد";
						TempData[InfoMessage] = "لطفا پس از ورود کلمه عبور خود را تغییر دهید";
						return RedirectToAction("Login");
                    case ForgotPasswordResult.NotFound:
						TempData[WarningMessage] = "کاربر مورد نظر یافت نشد";
                        break;
                    case ForgotPasswordResult.Error:
						TempData[ErrorMessage] = "شما با خطا مواجه شدید";
                        break;
						default:
						break;
                }
            }

            return View(forgotPassword);
        }

        #endregion

        #region Logout

        [HttpGet("log-out")]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();

			return Redirect("/");
		}

        #endregion
    }
}