using System.Collections.Generic;

using Data.Models;
using Data.Models.FoodMenus;
using Data.Models.TakeOuts;
using Data.Repositories;

namespace Data.ViewModels
{
    public class FoodMenuViewModel
    {
        //public List<Food> Foods { get; set; }

        private DatabaseRepository databaseRepository { get; set; }
        public List<FoodCategory> FoodCategoryList { get; set; }
        public List<FoodItem> FoodItemList { get; set; }
        //public List<OrderItem> OrderedItemList { get; set; }

        //public string OrderSubTotalCost { get; set; }
        //public string OrderTotalCost { get; set; }
        //public string OrderTotalSalesTax { get; set; }
        public FoodOrder CurrentTakeoutOrder { get; set; }

        public FoodItem FoodItemToAddEdit { get; set; }

        public void GetFoodItemsAndCategories()
        {
            FoodCategoryList = databaseRepository.GetFoodCategories();
            FoodItemList = databaseRepository.GetFoodItems();
        }

        public FoodMenuViewModel()
        {
            databaseRepository = new DatabaseRepository();

            FoodCategoryList = new List<FoodCategory>();
            FoodItemList = new List<FoodItem>();
            CurrentTakeoutOrder = new FoodOrder();

            GetFoodItemsAndCategories();
        }
    }
}
