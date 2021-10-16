using System.Collections.Generic;
using Data.Models;
namespace RamenOkiDoki.ViewModels
{
    public class FoodItemsViewModel
    {
        public List<Food> Foods { get; set; }
        public List<FoodItem> FoodItems { get; set; }
        public List<OrderItem> OrderedItems { get; set; }
        public List<string> FoodCategories { get; set; }

        public string OrderTotalCost { get; set; }
    }
}
