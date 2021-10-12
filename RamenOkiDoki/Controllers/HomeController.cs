using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RamenOkiDoki.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using RamenOkiDoki.Helpers;
using RamenOkiDoki.Services;

namespace RamenOkiDoki.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MenuEndpointService _menuEndpointService { get; set;}

        public HomeController(ILogger<HomeController> logger, MenuEndpointService menuEndpointService)
        {
            _logger = logger;
            _menuEndpointService = menuEndpointService;
        }

        public IActionResult Index()
        {
            return View();
        }

      public async Task<IActionResult> FoodItemMenu()
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
