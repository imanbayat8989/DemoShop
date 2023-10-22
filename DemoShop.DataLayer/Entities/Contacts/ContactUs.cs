using DemoShop.DataLayer.Entities.Account;
using DemoShop.DataLayer.Entities.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoShop.DataLayer.Entities.Contacts
{
    public class ContactUs : BaseEntities
    {
        #region properties

        public long? UserId { get; set; }
        [Display(Name = "ایپی کاربر")]
        [Required(ErrorMessage = "لطفاً {0} وارد کنید")]
        [MaxLength(50, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
        public string UserIp { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفاً {0} وارد کنید")]
        [MaxLength(50, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Email { get; set; }
        [Display(Name = "نام کامل")]
        [Required(ErrorMessage = "لطفاً {0} وارد کنید")]
        [MaxLength(50, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
        public string FullName { get; set; }
        [Display(Name = "موضوع")]
        [Required(ErrorMessage = "لطفاً {0} وارد کنید")]
        [MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Subject { get; set; }
        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفاً {0} وارد کنید")]
        [MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Text { get; set; }
        #endregion
        #region Relation

        public User user { get; set; }

        #endregion


    }
}