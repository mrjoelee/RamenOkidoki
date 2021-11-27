using System;
using System.Collections.Generic;
using System.Web;
using Data.Models;
using Data.Models.Constants;
using Data.Models.DashboardData;
using Data.Models.FoodMenus;
using Data.Models.TakeOuts;
using Data.Models.User;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<AddOnCharges> AddOns { get; set; }

        public DbSet <FoodCategory> FoodCategories { get; set; }
        public DbSet <FoodItem> FoodItems { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }

       public DbSet <OrderItem> OrderItems { get; set; }
        public DbSet<CustomerReview> CustomerReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Keys.OkiDokiDbConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}