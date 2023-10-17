using DemoShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoShop.Web.Controllers
{
	public class HomeController : SiteBaseController
	{

		#region register
		public IActionResult Index()
		{
			return View();
		}
		#endregion
	}
}