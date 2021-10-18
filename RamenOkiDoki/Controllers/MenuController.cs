using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data.Models;
using Data.ViewModels;

using Microsoft.AspNetCore.Mvc;

using RamenOkiDoki.Services;

namespace RamenOkiDoki.Controllers
{
    public class MenuController : Microsoft.AspNetCore.Mvc.Controller
    {
        private MenuEndpointService _menuEndpointService { get; set; }

        public MenuController(MenuEndpointService menuEndpointService)
        {
            _menuEndpointService = menuEndpointService;
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<FoodItemsViewModel> MakeMenu()
        {
            Globals.FoodCategoriesList = await _menuEndpointService.GetFoodItemsFromCloud();

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.FoodCategoriesList = new List<FoodMenu.FoodCategory>();


            if (Globals.FoodCategoriesList != null)
            {
                foodItemsViewModel.FoodCategoriesList = Globals.FoodCategoriesList;
            }


            return foodItemsViewModel;
        }

        #region =  Dine In Menu

        [Route("menu")]
        public async Task<IActionResult> DineInMenu()
        {
            var foodItemsViewModel = await MakeMenu();

            return View(foodItemsViewModel);
        }



        #endregion

        #region = Take Out Menu

        [Route("take-out")]
        public async Task<IActionResult> TakeOutMenu(string categoryString)
        {
            var foodItemsViewModel = await MakeMenu();

            foodItemsViewModel.FoodItems = new List<FoodMenu.FoodItem>();

                   foreach (var cat in Globals.FoodCategoriesList)
                   {
                       if (cat.FoodItems.Count >3)
                       {
                           foodItemsViewModel.FoodItems = cat.FoodItems;
                       }
                   }

         


            return View(foodItemsViewModel);

            foodItemsViewModel.FoodCategories = new List<string>();

            foreach (var category in foodItemsViewModel.FoodCategoriesList)
            {
                if (category.FoodItems != null && category.FoodItems.Count > 0)
                {
                      foodItemsViewModel.FoodCategories.Add(category.FoodItems[0].foodCategory);
                }
              
            }

            foodItemsViewModel.FoodCategories.Distinct().ToString();





            if (string.IsNullOrWhiteSpace(categoryString))
            {
                if (foodItemsViewModel.FoodCategories.Count > 0)
                {
                    categoryString = foodItemsViewModel.FoodCategories[0];
                }

                if (Globals.CurrentCategory != null)
                {
                    foreach (var category in foodItemsViewModel.FoodCategories)
                    {
                        if (category == Globals.CurrentCategory)
                        {
                            categoryString = category;
                        }
                    }
                }

                Globals.CurrentCategory = categoryString;

            }

            foodItemsViewModel.FoodItems = new List<FoodMenu.FoodItem>();

            foreach (var categoryItem in foodItemsViewModel.FoodCategoriesList)
            {
                if (true)//categoryItem.Category == (categoryString))
                {
                    //if (categoryItem.FoodItems != null)
                    //{
                    foodItemsViewModel.FoodItems = categoryItem.FoodItems;
                    //  }

                }
            }


            return View(foodItemsViewModel);
        }

        #endregion
    }
}

