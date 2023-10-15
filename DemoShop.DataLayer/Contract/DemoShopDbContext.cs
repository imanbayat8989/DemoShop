using DemoShop.DataLayer.Entities.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.Contract
{
	public class DemoShopDbContext: DbContext
	{
		#region DbSets
		public DbSet<User> Users { get; set; }
		#endregion
	}
}
