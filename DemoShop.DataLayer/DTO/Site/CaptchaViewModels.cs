using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.DTO.Site
{
	public class CaptchaViewModels
	{
	
		[Required(ErrorMessage = "لطفا {0} وارد کنید")]
        public string Captcha { get; set; }
    }
}
