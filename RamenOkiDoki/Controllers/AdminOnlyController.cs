using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RamenOkiDoki.Models;
using RamenOkiDoki.Services;
using RamenOkiDoki.ViewModels;

namespace RamenOkiDoki.Controllers
{
    public class AdminOnlyController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MenuEndpointService _menuEndpointService;

        public AdminOnlyController(ILogger<HomeController> logger, MenuEndpointService menuEndpointService)
        {
            _logger = logger;
            _menuEndpointService = menuEndpointService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> FoodMenuEdit()
        {
            List<FoodItem> FoodItems = await _menuEndpointService.GetFoodItemsFromCloud();

            if (FoodItems == null)
            {
                return null;
            }

            FoodItems.OrderBy(categoryName => categoryName);

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.FoodItems = FoodItems;

            return View(foodItemsViewModel);
        }


        public async Task<IActionResult> FoodMenuAdmin()
        {
            List<FoodItem> FoodItems = await _menuEndpointService.GetFoodItemsFromCloud();

            if (FoodItems == null)
            {
                return null;
            }

            FoodItems.OrderBy(categoryName => categoryName);
            
            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.FoodItems = FoodItems;

            return View(foodItemsViewModel);
        }
    }
}

