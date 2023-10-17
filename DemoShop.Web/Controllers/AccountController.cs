using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Account;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Controllers
{
	public class AccountController : SiteBaseController
	{
		#region Constructor
		private readonly IUserService _userService;

		public AccountController(IUserService userService)
		{
			_userService = userService;
		}

		#endregion

		#region Register

		[HttpGet("register")]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost("register"), ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterUserDTO register)
		{
			if (ModelState.IsValid)
			{
				var res = await _userService.RegisterUser(register);
				switch (res)
				{
					case RegisterUserResult.MobileExists:
						TempData["ErrorMessage"] = "تلفن همراه وارد شده تکراری است";
						ModelState.AddModelError("Mobile", "تلفن همراه وارد شده تکراری است");
						break;
					case RegisterUserResult.Success:
						TempData["SuccessMessage"] = "ثبت نام شما با موفقیت انجام شد";
						TempData["InfoMessage"] = "کد تایید تلفن همراه برای شما ارسال شد";
						return RedirectToAction("Login");
					case RegisterUserResult.Error:
						TempData["ErrorMessage"] = "با خطا مواجه شدید";
						ModelState.AddModelError("", "با خطا مواجه شدید");
						break;
				}
			}
			return View(register);
		}

		#endregion

		#region Login

		public IActionResult Login()
		{
			return View();
		}

		#endregion
	}
}
