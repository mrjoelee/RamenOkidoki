using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using RamenOkiDoki.Services;
using RamenOkiDoki.ViewModels;

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

        [Route("menu")]
        public async Task<IActionResult> DineInMenu()
        {
            Globals.FoodItems = await _menuEndpointService.GetFoodItemsFromCloud();

            if (Globals.FoodItems == null)
            {
                return null;
            }


            Globals.FoodItems.OrderBy(categoryName => categoryName);

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.FoodItems = Globals.FoodItems;

            return View(foodItemsViewModel);
        }


        [Route("take-out")]
        public async Task<IActionResult> TakeOutMenu(string category)
        {
            List<FoodItem> tempListOfMenuItemsToReturn = new List<FoodItem>();

            // Get from MySql Database
            Globals.FoodItems = await _menuEndpointService.GetFoodItemsFromCloud();

            if (Globals.FoodItems == null)
            {
                return null;
            }

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            List<string> tempListOfCategoryItems = new List<string>();

            foreach (var items in Globals.FoodItems)
            {
                tempListOfCategoryItems.Add(items.categoryName);
            }

            foodItemsViewModel.FoodCategories = tempListOfCategoryItems.Distinct().ToList();


            if (string.IsNullOrWhiteSpace(category))
            {
                if (string.IsNullOrWhiteSpace(Globals.CurrentCategory))
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
                if (item.categoryName == (category))
                {
                    tempListOfMenuItemsToReturn.Add(item);
                }
            }

            foodItemsViewModel.FoodItems = tempListOfMenuItemsToReturn;

            return View(foodItemsViewModel);
        }

      
    }
}
