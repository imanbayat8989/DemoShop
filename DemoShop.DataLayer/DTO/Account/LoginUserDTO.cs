using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoShop.DataLayer.DTO.Account
{
    public class LoginUserDTO
    {
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفاً {0} وارد کنید")]
        [MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Mobile { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفاً {0} وارد کنید")]
        [MaxLength(200, ErrorMessage = "نمی تواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public enum LoginUserResult
    {
        Success,
        NotFound,
        NotActiveted
    }
}
