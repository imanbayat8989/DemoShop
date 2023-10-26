using DemoShop.DataLayer.Entities.Account;
using DemoShop.DataLayer.Entities.Contacts;
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
		public DbSet<ContactUs> ContactUs { get; set; }
		public DbSet<Slider> Slider { get; set; }
		public DbSet<SiteBanner> SiteBanner { get; set; }
		public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        #endregion

        #region on model creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

			base.OnModelCreating(modelBuilder);
		}
		#endregion
	}
}
