using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Controllers
{
	public class SiteBaseController : Controller
	{
		protected string ErrorMessage = "ErrorMessage";
		protected string SuccessMessage = "SuccessMessage";
		protected string InfoMessage = "InfoMessage";
		protected string WarningMessage = "WarningMessage";
	}
}
