using DemoShop.DataLayer.Entities.Account;
using DemoShop.DataLayer.Entities.Site;
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
        public DemoShopDbContext(DbContextOptions<DemoShopDbContext> options) : base(options) { }
        #region DbSets
        public DbSet<User> Users { get; set; }
		public DbSet<SiteSettings> SiteSettings { get; set; }
		#endregion

		#region on model creating
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Cascade;
			}

			base.OnModelCreating(modelBuilder);
		}
		#endregion
	}
}
