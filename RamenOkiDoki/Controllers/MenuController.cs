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
            Globals.FoodCategories = await _menuEndpointService.GetFoodItemsFromCloud();

            if (Globals.FoodItems == null)
            {
                return null;
            }


            Globals.FoodItems.OrderBy(categoryName => categoryName);

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.FoodItems = Globals.FoodItems;

            return View(foodItemsViewModel);
        }

        #endregion

        #region = Take Out Menu

        [Route("take-out")]
        public async Task<IActionResult> TakeOutMenu(string categoryString)
        {
            FoodCategory category = null;

            if (string.IsNullOrWhiteSpace(categoryString))
            {
                category = new FoodCategory(categoryString);
            }

            List<FoodMenu.FoodItem> tempListOfMenuItemsToReturn = new List<FoodMenu.FoodItem>();

            // Get from MySql Database
            Globals.FoodCategories = await _menuEndpointService.GetFoodItemsFromCloud();

            if (Globals.FoodCategories == null)
            {
                return null;
            }

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            List<FoodCategory> tempListOfCategoryItems = new List<FoodCategory>();

            foreach (var items in Globals.FoodItems)
            {
                tempListOfCategoryItems.Add(items.foodCategory);
            }

            foodItemsViewModel.FoodCategories = tempListOfCategoryItems.Distinct().ToList();


            if (category == null)
            {
                if (Globals.CurrentCategory == null)
                {
                    category = foodItemsViewModel.FoodCategories[0];
                }
                else
                {
                    category = Globals.CurrentCategory;
                }
            }

            foreach (var item in Globals.FoodItems)
            {
                if (item.foodCategory == (category))
                {
                    tempListOfMenuItemsToReturn.Add(item);
                }
            }

            foodItemsViewModel.FoodItems = tempListOfMenuItemsToReturn;

            return View(foodItemsViewModel);
        }

        #endregion
    }
}
