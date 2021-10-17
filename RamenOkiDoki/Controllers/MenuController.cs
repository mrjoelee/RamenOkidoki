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

        #region =  Dine In Menu

        [Route("menu")]
        public async Task<IActionResult> DineInMenu()
        {
            Globals.FullFoodMenuList = await _menuEndpointService.GetFoodItemsFromCloud();

            if (Globals.FoodItemsList == null)
            {
                return null;
            }


            Globals.FoodItemsList.OrderBy(categoryName => categoryName);

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.FoodItems = Globals.FoodItemsList;

            return View(foodItemsViewModel);
        }

        #endregion

        #region = Take Out Menu

        [Route("take-out")]
        public async Task<IActionResult> TakeOutMenu(string categoryString)
        {
            List<FoodMenu.FoodItem> tempListOfMenuItemsToReturn = new List<FoodMenu.FoodItem>();

            // Get from MySql Database
            Globals.FullFoodMenuList = await _menuEndpointService.GetFoodItemsFromCloud();

            if (Globals.FullFoodMenuList == null)
            {
                return null;
            }

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            List<string> tempListOfCategoryItems = new List<string>();

            foreach (var foodCategory in Globals.FullFoodMenuList)
            {
                tempListOfCategoryItems.Add(foodCategory.FoodItems.ToString());
            }

            foodItemsViewModel.FoodCategories = tempListOfCategoryItems.Distinct().ToList();


            if (string.IsNullOrWhiteSpace(categoryString))
            {
                if (Globals.CurrentCategory == null)
                {
                    categoryString = Globals.FullFoodMenuList[0].Category;
                }
                else
                {
                    categoryString = Globals.CurrentCategory;
                }
            }

            foreach (var categoryItem in Globals.FullFoodMenuList)
            {
                if (categoryItem.Category == (categoryString))
                {
                    tempListOfMenuItemsToReturn = categoryItem.FoodItems;
                }
            }

            foodItemsViewModel.FoodItems = tempListOfMenuItemsToReturn;

            return View(foodItemsViewModel);
        }

        #endregion
    }
}
