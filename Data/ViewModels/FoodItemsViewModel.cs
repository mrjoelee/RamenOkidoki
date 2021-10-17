using System.Collections.Generic;

using Data.Models;

namespace Data.ViewModels
{
    public class FoodItemsViewModel
    {
        public List<Food> Foods { get; set; }
        public List<FoodMenu.FoodItem> FoodItems { get; set; }
        public List<OrderItem> OrderedItems { get; set; }
        public List<string> FoodCategories { get; set; }
        public string OrderTotalCost { get; set; }
    }
}
