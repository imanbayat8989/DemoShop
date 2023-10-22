using DemoShop.Application.Implementation;
using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Account;
using DemoShop.DataLayer.DTO.Contacts;
using DemoShop.Web.Models;
using DemoShop.Web.PresentationExtensions;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoShop.Web.Controllers
{
	public class HomeController : SiteBaseController
	{
        #region Constructor

		private readonly IContactusService _contactusService;
        private readonly ICaptchaValidator _captchaValidator;

        public HomeController(IContactusService contactusService, ICaptchaValidator captchaValidator)
        {
            _contactusService = contactusService;
            _captchaValidator = captchaValidator;
        }


        #endregion

        #region Contact Us
        [HttpGet("contact-us")]
        public async Task<IActionResult> ContactUs()
        {
            return View();
        }
        [HttpPost("contact-us"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(CreateContactUsDTO createContactUsDTO)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(createContactUsDTO.Captcha))
            {
                TempData[ErrorMessage] = "کد کپچای شما تایید نشد";
                return View(createContactUsDTO);
            }
            if (ModelState.IsValid)
            {
                var Ip = HttpContext.GetUserIp();
                await _contactusService.CreateContactUs(createContactUsDTO,HttpContext.GetUserIp(), User.GetUserId());
                TempData[SuccessMessage] = "پیام شما با موفقیت ارسال شد";
                return RedirectToAction("ContactUs");

            }
            return View(createContactUsDTO);
        }

        #endregion

        #region register
        public async Task<IActionResult> Index(string mobile)
		{
			
			return View();
		}
		#endregion
	}
}