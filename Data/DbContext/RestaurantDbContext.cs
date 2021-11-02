using System;
using System.Web;
using Data.Models.DashboardData;
using Data.Models.FoodMenus;
using Data.Models.TakeOuts;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.MetaData;

namespace Data.DbContext
{
    public class RestaurantDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public RestaurantDbContext()
        {
                
        }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
                
        }

        public DbSet<BusinessLocation> BusinessLocations { get; set; }

        public DbSet<HoursOfOperation> BusinessHours { get; set; }
        public DbSet<FoodMenu.FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodMenu.FoodItem> FoodItems { get; set; }

        public DbSet<Customer> Customers  { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<AddOnCharges> AddOns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=plesk6000.is.cc;Initial Catalog=OkiDokiDb;Persist Security Info=True;User ID=okidoki001;Password=OkiDokiPwd!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}