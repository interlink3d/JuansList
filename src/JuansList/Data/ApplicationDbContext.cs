using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JuansList.Models;

namespace JuansList.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<VendorUser> VendorUser { get; set; }
        public DbSet<CustomerUser> CustomerUser { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<AlbumImages> AlbumImages { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<VendorCategory> VendorCategory { get; set; }
        public DbSet<Coupon> Coupon { get; set; }
        public DbSet<Estimate> Estimate { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Review> Review { get; set; }

    }
}
