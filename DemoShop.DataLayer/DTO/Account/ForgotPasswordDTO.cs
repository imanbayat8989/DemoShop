using DemoShop.DataLayer.DTO.Site;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.DTO.Account
{
	public class ForgotPasswordDTO : CaptchaViewModels
	{
		[Display(Name = "Forgot-pass")]
		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string Mobile { get; set; }
    }

	public enum ForgotPasswordResult
	{
        Success,
        NotFound,
        Error
    }
}
