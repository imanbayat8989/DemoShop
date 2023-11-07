using DemoShop.Application.Implementation;
using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Account;
using DemoShop.DataLayer.DTO.Common;
using DemoShop.DataLayer.DTO.Contacts;
using DemoShop.DataLayer.Entities.Site;
using DemoShop.Web.Models;
using DemoShop.Web.PresentationExtensions;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoShop.Web.Controllers
{
	public class HomeController : SiteBaseController
	{
        #region constructor

        private readonly IContactusService _contactService;
        private readonly ICaptchaValidator _captchaValidator;
        private readonly ISiteService _siteService;
        private readonly IUserService _userService;
   

        public HomeController(IContactusService contactService, ICaptchaValidator captchaValidator, ISiteService siteService, IUserService userService)
        {
            _contactService = contactService;
            _captchaValidator = captchaValidator;
            _siteService = siteService;
            _userService = userService;
           
        }

        #endregion

        #region index

        public async Task<IActionResult> Index()
        {
            ViewBag.banners = await _siteService
                .GetSiteBannersByPlacement(new List<BannerPlacement>
                {
                    BannerPlacement.Home_1,
                    BannerPlacement.Home_2,
                    BannerPlacement.Home_3
                });

           
            return View();
        }

        #endregion

        #region contact us

        [HttpGet("contact-us")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost("contact-us"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(CreateContactUsDTO contact)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(contact.Captcha))
            {
                TempData[ErrorMessage] = "کد کپچای شما تایید نشد";
                return View(contact);
            }

            if (ModelState.IsValid)
            {
                var ip = HttpContext.GetUserIp();
                await _contactService.CreateContactUs(contact, HttpContext.GetUserIp(), User.GetUserId());
                TempData[SuccessMessage] = "پیام شما با موفقیت ارسال شد";
                return RedirectToAction("ContactUs");
            }

            return View(contact);
        }

        #endregion

        #region about us

        [HttpGet("about-us")]
        public async Task<IActionResult> AboutUs()
        {
            var siteSetting = await _siteService.GetDefaultSiteSetting();
            return View(siteSetting);
        }

        #endregion
    }
}