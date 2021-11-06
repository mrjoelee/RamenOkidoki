﻿using System.Collections.Generic;

using Data.Models;
using Data.Models.FoodMenus;

namespace Data.ViewModels
{
    public class FoodItemsViewModel
    {
        //public List<Food> Foods { get; set; }
        public List<FoodItem> FoodItems { get; set; }
        public List<OrderItem> OrderedItems { get; set; }
        public List<string> FoodCategories { get; set; }
        public string OrderSubTotalCost { get; set; }
        public string OrderTotalCost { get; set; }
        public string OrderTotalSalesTax { get; set; }


        public List<FoodCategory> FoodCategoriesList { get; set; }

        public FoodItemsViewModel()
        {
           // Foods = new List<Food>();
            FoodItems = new List<FoodItem>();
            OrderedItems = new List<OrderItem>();
            FoodCategories = new List<string>();
            FoodCategoriesList = new List<FoodCategory>();


        }
    }
}
