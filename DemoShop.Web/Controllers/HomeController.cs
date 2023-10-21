using DemoShop.Application.Interface;
using DemoShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoShop.Web.Controllers
{
	public class HomeController : SiteBaseController
	{
		#region Constructor

		#endregion

		#region register
		public async Task<IActionResult> Index(string mobile)
		{
			
			return View();
		}
		#endregion
	}
}