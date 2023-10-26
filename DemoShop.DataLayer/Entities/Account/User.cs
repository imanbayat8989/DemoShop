using DemoShop.DataLayer.Entities.common;
using DemoShop.DataLayer.Entities.Contacts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.Entities.Account
{
	public class User : BaseEntities
	{
        #region Properties
        [Display(Name ="ایمیل")]
        [MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string EmailActiveCode { get; set; }

        [Display(Name = "ایمیل فعال / غیر فعال")]
        public bool IsEmailActive { get; set; }

		[Display(Name = "تلفن همراه")]
		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string Mobile { get; set; }

		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string MobileActiveCode { get; set; }

        [Display(Name ="همراه فعال / غیرفعال")]
		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public bool IsMobileActive { get; set; }

		[Display(Name = "رمز عبور")]
		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string Password { get; set; }

		[Display(Name = "نام")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string FirstName { get; set; }

		[Display(Name = "آواتار")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string? Avatar { get; set; }

		[Display(Name = "فامیل")]
		[Required(ErrorMessage = "لطفاً {0} وارد کنید")]
		[MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
		public string LastName { get; set; }

		[Display(Name = "بلاک شده / نشده")]
		public bool IsBlocked { get; set; }

        #endregion

        #region Relations

		public ICollection<ContactUs> ContactUses { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<TicketMessage> TicketMessages { get; set; }
        #endregion
    }
}
