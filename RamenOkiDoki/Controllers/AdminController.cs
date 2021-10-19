using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data.Models;
using Data.Models.FoodMenus;
using Data.ViewModels;
using DataServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RamenOkiDoki.Controllers
{
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MenuEndpointService _menuEndpointService;

        //  public List<FoodItem> FoodItemsList;

        public AdminController(ILogger<HomeController> logger, MenuEndpointService menuEndpointService)
        {
            _logger = logger;
            _menuEndpointService = menuEndpointService;
        }

        //returns the users to the index(home of the index view page)
        public IActionResult Index()
        {
            return View();
        }


        private async Task<FoodItemsViewModel> MakeMenu()
        {
            Globals.FoodCategoriesList = await _menuEndpointService.GetFoodItemsFromCloud();

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            if (Globals.FoodCategoriesList != null)
            {
                foodItemsViewModel.FoodCategoriesList = Globals.FoodCategoriesList;
            }

            return foodItemsViewModel;
        }


        //Gets the menu from cloud via SQL DB - and returns the view as Food Items which is created in FoodItemsviewModel
        public async Task<IActionResult> FoodMenuEdit()
        {
            var foodItemsViewModel = await MakeMenu();

            return View(foodItemsViewModel);

            //FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            //Globals.FoodCategoriesList = await _menuEndpointService.GetFoodItemsFromCloud();

            //if (Globals.FoodCategory != null)
            //{
            //    Globals.FoodItemsList.OrderBy(dishName => dishName);
            //    foodItemsViewModel.FoodItems = Globals.FoodItemsList;

            //}

            return View(foodItemsViewModel);
        }


        //Creates new item and returns to the menu.
        public IActionResult FoodMenuAddEdit(int? id)
        {
            if (id != null)
            {
                int index = (int)id;
                int itemId;

                foreach (var item in Globals.FoodItemsList)
                {
                    int.TryParse(item.id, out itemId);

                    if (itemId == index)
                    {
                        return View(item);
                    }
                }
            }

            return View();
        }
        #region saving new item
        public async Task<IActionResult> PutMenuItem(FoodMenu.FoodItem item)
        {
            await _menuEndpointService.AddMenuItemToCloud(item);
            return Redirect("FoodMenuEdit");
        }
        #endregion

        #region deleting  item
        public async Task<IActionResult> DeleteMenuItem(int? id)
        {
            if (id != null)
            {
                int index = (int)id;
                int itemId;

                foreach (var item in Globals.FoodItemsList)
                {
                    int.TryParse(item.id, out itemId);

                    if (itemId == index)
                    {
                        await _menuEndpointService.DeleteMenuItemFromCloud(index);
                    }
                }
            }

            return RedirectToAction("FoodMenuEdit");
        }
        #endregion


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

        public IActionResult DashBoard()
        {
            return View("Index");
        }
    }
}

