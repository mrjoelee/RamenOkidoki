using System.Collections.Generic;

using Data.Models;
using Data.Models.FoodMenus;

namespace Data.ViewModels
{
    public class FoodItemsViewModel
    {
        //public List<Food> Foods { get; set; }
        
        public List<FoodCategory> FoodCategoryList { get; set; }
        public List<FoodItem> FoodItemList { get; set; }
        public List<OrderItem> OrderedItemList { get; set; }


        public string OrderSubTotalCost { get; set; }
        public string OrderTotalCost { get; set; }
        public string OrderTotalSalesTax { get; set; }

        
        public FoodItemsViewModel()
        {
           // Foods = new List<Food>();
            FoodCategoryList = new List<FoodCategory>();
            FoodItemList = new List<FoodItem>();
            OrderedItemList = new List<OrderItem>();

          


        }
    }
}
