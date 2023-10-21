using DemoShop.DataLayer.DTO.Site;
using DemoShop.DataLayer.Entities.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoShop.DataLayer.DTO.Account
{
	public class ActivateMobileDTO : CaptchaViewModels
	{
		[Display(Name = "موبایل")]
		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string Mobile { get; set; }

        [Display(Name = "کد فعالسازی تلفن همراه")]
        [Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string MobileActiveCode { get; set; }
	}
}
