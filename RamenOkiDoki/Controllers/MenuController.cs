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
            List<FoodItem> FoodItems = await _menuEndpointService.GetFoodItemsFromCloud();

            if (FoodItems == null)
            {
                return null;
            }

            FoodItems.OrderBy(categoryName => categoryName);

            FoodItemsViewModel indexViewModel = new FoodItemsViewModel();
            indexViewModel.FoodItems = FoodItems;
            return View(indexViewModel);
        }

      
        [Route("take-out")]
        public async Task<IActionResult> TakeOutMenu()
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

        public IActionResult FilterByCategory(string Category)
        {

            return View();
        }
    }
}
