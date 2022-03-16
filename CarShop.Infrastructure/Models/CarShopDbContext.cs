using CarShop.Infrastructure.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Infrastructure.Models
{
    public class CarShopDbContext : DbContext
    {
        public CarShopDbContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ValuteTypeConfiguration());
        }
    }
}
