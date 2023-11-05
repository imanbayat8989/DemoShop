using DemoShop.DataLayer.DTO.Products;
using DemoShop.DataLayer.Entities.Account;
using DemoShop.DataLayer.Entities.Contacts;
using DemoShop.DataLayer.Entities.Product;
using DemoShop.DataLayer.Entities.Site;
using DemoShop.DataLayer.Entities.Store;
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
        #region account

        public DbSet<User> Users { get; set; }

        #endregion

        #region site

        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SiteBanner> SiteBanners { get; set; }

        #endregion

        #region contacts

        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }

        #endregion

        #region store

        public DbSet<Seller> Sellers { get; set; }

        #endregion

        #region products

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductGallery> ProductGalleries { get; set; }

        public DbSet<ProductSelectedCategory> ProductSelectedCategories { get; set; }

        public DbSet<ProductColor> ProductColors { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

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
