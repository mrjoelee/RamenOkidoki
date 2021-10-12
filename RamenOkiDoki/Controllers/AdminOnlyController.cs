using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RamenOkiDoki.Models;
using RamenOkiDoki.Services;

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


            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.FoodItems = FoodItems;
            return View(indexViewModel);
        }


        public async Task<IActionResult> FoodMenuAdmin()
        {
            List<FoodItem> FoodItems = await _menuEndpointService.GetFoodItemsFromCloud();

            if (FoodItems == null)
            {
                return null;
            }

            FoodItems.OrderBy(categoryName => categoryName);


            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.FoodItems = FoodItems;
            return View(indexViewModel);
        }
    }
}

