using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoShop.DataLayer.DTO.Account
{
	public class RegisterUserDTO
	{
		[Display(Name = "ایمیل")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		[EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }

		[Display(Name = "موبایل")]
		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]

		public string Mobile { get; set; }
		[Display(Name = "نام")]
		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string FirstName { get; set; }
		[Display(Name = " نام خوانوادگی")]
		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string LastName { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفاً {0} وارد کنید")]
        [MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Password { get; set; }
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "کلمه عبور مغایرت دارد")]
        [MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
        public string ConfirmPassword { get; set; }

    }

	public enum RegisterUserResult
	{
		Success,
		MobileExists,
		Error
	}
}
