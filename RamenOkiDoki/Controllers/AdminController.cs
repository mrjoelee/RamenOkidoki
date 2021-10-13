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
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MenuEndpointService _menuEndpointService;

        public AdminController(ILogger<HomeController> logger, MenuEndpointService menuEndpointService)
        {
            _logger = logger;
            _menuEndpointService = menuEndpointService;
        }

        public IActionResult Index()
        {
            return View();
        }

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

        public IActionResult FoodMenuAddEdit(int? id)
        {
            return View();

        }

        public IActionResult DeleteMenuItem(int? id)
        {
            return Redirect("FoodMenuEdit");
        }

        public IActionResult ModalPopUp(int? id)
        {
            return View();
        }

        public IActionResult AdminSignin()
        {
            Globals.UserSignedIn = true;

            Globals.UserRole = Globals.UserRoles.Admin;

            return Redirect("Index");
        }
        public IActionResult AdminSignOut()
        {
            Globals.UserSignedIn = false;

            Globals.UserRole = Globals.UserRoles.Patron;//Globals.UserRoles.Admin;

            return Redirect("Index");

        }
    }
}

