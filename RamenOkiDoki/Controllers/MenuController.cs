using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using RamenOkiDoki.Models;
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
            List<FoodItem> listToReturn = new List<FoodItem>();

            Globals.FoodItems = await _menuEndpointService.GetFoodItemsFromCloud();

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            if (Globals.FoodItems == null)
            {
                return null;
            }

            category = "Beverages";

            if (string.IsNullOrWhiteSpace(category))
            {
                  Globals.FoodItems.OrderBy(categoryName => categoryName);     
                  
                  foodItemsViewModel.FoodItems = Globals.FoodItems;
            }
            else
            {
                foreach (var item in Globals.FoodItems)
                {
                    if (item.categoryName == (category))
                    {
                        listToReturn.Add(item);
                    }
                }
                
                foodItemsViewModel.FoodItems = listToReturn;
            }
          
            return View(foodItemsViewModel);
        }

        public IActionResult FilterByCategory(string Category)
        {

            return View();
        }
    }
}
