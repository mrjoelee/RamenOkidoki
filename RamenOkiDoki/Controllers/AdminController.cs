using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RamenOkiDoki.Services;
using RamenOkiDoki.ViewModels;

namespace RamenOkiDoki.Controllers
{
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MenuEndpointService _menuEndpointService;

        //  public List<FoodItem> FoodItems;

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

        //Gets the menu from cloud via SQL DB - and returns the view as Food Items which is created in FoodItemsviewModel
        public async Task<IActionResult> FoodMenuEdit()
        {
            Globals.FoodItems = await _menuEndpointService.GetFoodItemsFromCloud();

            if (Globals.FoodItems == null)
            {
                return null;
            }

            Globals.FoodItems.OrderBy(dishName => dishName);

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.FoodItems = Globals.FoodItems;

            return View(foodItemsViewModel);
        }


        //Creates new item and returns to the menu.
        public IActionResult FoodMenuAddEdit(int? id)
        {
            if (id != null)
            {
                int index = (int)id;
                int itemId;

                foreach (var item in Globals.FoodItems)
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
        public async Task<IActionResult> PutMenuItem(FoodItem item)
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

                foreach (var item in Globals.FoodItems)
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
    }
}

