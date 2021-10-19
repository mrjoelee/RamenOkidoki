﻿using System.Collections.Generic;
using System.Collections.Immutable;
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
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return View(dashboardViewModel);
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

            foodItemsViewModel.FoodItems = new List<FoodMenu.FoodItem>();

            Globals.FoodCategoriesList = new List<FoodMenu.FoodCategory>();

            foreach (var categories in Globals.FoodCategoriesList)
            {
                if (categories != null && categories.FoodItems.Count > 0)
                {

                    foreach (var fooditems in categories.FoodItems)
                    {
                        if (fooditems != null)
                        {
                            foodItemsViewModel.FoodItems.Add(fooditems);
                        }
                    }
                }
            }

            return View(foodItemsViewModel);
        }


        //Creates new item and returns to the menu.
        public async Task<IActionResult> FoodMenuAddEdit(int? id)
        {
            if (id != null)
            {
                int index = (int)id;
                int itemId;

                if (Globals.FoodCategoriesList == null || Globals.FoodCategoriesList.Count < 1)
                {
                    Globals.FoodCategoriesList = await _menuEndpointService.GetFoodItemsFromCloud();
                }

                foreach (var category in Globals.FoodCategoriesList)
                {
                    if (category.FoodItems != null && category.FoodItems.Count > 0)
                    {


                        foreach (var item in category.FoodItems)
                        {
                            if (item != null)
                            {
                                int.TryParse(item.id, out itemId);

                                if (itemId == index)
                                {
                                    return View(item);
                                }
                            }

                        }
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

