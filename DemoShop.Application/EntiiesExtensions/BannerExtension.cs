using DemoShop.Application.Utils;
using DemoShop.DataLayer.Entities.common;
using DemoShop.DataLayer.Entities.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.EntiiesExtensions
{
	public static class BannerExtension 
	{
		public static string GetBannerMainImageAddress(this SiteBanner banner)
		{
			return PathExtensions.BannerOrigin + banner.ImageName;
		}
	}
}
