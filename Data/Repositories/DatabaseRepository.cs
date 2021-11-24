using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.DbContext;
using Data.Models;
using Data.Models.DashboardData;
using Data.Models.FoodMenus;
using Data.Models.TakeOuts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data.Repositories
{
    public class DatabaseRepository
    {
        private RestaurantDbContext _context;
        public DatabaseRepository()
        {
            _context = new RestaurantDbContext();
        }

        public BusinessLocation GetBusinessLocation()
        {
            BusinessLocation businessLocation = _context.BusinessLocations.First() as BusinessLocation;



            return businessLocation;
        }

        public HoursOfOperation GetHoursOfOperation()
        {
            HoursOfOperation hoursOfOperation = _context.BusinessHours.FirstOrDefault();

            return hoursOfOperation;
        }

        public List<CustomerReview> GetCustomerReviews()
        {
            List<CustomerReview> customerReviews = _context.CustomerReviews.ToList();

            return customerReviews;
        }

        public AddOnCharges GetAddOnCharges()
        {
            AddOnCharges addOnCharges = _context.AddOns.FirstOrDefault();

            return addOnCharges;
        }



        public List<FoodCategory> GetFoodCategories()
        {
            List<FoodCategory> foodCategories = _context.FoodCategories.ToList();

            return foodCategories;
        }

        public List<FoodItem> GetFoodItems()
        {
            List<FoodItem> foodItems = _context.FoodItems.ToList();

            return foodItems;
        }

       //public List<FoodOrder> GetFoodOrders()
       // {
       //     List<FoodOrder> foodOrders = _context.FoodOrders.ToList();

       //     return foodOrders;
       // }
       

        public void SaveRestaurantData<T>(T data)
        {
            _context.Update(data);

            _context.SaveChanges();
        }
        public void AddRestaurantData<T>(T data)
        {
            _context.Update(data);

            _context.SaveChanges();
        }

        //public void AddOrUpdateRestaurantData<T>(T data)
        //{

        //    _context.Update(data);

        //    _context.SaveChanges();
        //}

        public void DeleteItem<T>(T item)
        {
            _context.Remove(item);

            _context.SaveChanges();
        }

        //public void AddRestaurantDataList <T> (List<T> dataList)
        //{
        //    _context.Add(dataList);

        //    _context.SaveChanges();
        //}
    }
}
