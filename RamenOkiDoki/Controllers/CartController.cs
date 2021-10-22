using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Models.FoodMenus;
using Data.ViewModels;
using DataServices.Services;

namespace RamenOkiDoki.Controllers
{
    public class CartController : Controller
    {
        private MenuEndpointService _menuEndpointService { get; set; }

        public CartController(MenuEndpointService menuEndpointService)
        {
            _menuEndpointService = menuEndpointService;
            // Globals.CartItemsList = new List<OrderItem>();
        }

        public async Task<IActionResult> Index()
        {
            //Bring in the complete menu from cloud in a list of categories and their items

            //Globals.FullFoodMenuList = await _menuEndpointService.GetFoodItemsFromCloud();

            //if (Globals.FullFoodMenuList == null)
            //{
            //    return null;
            //}

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            //List<OrderItem> tempOrderList = new List<OrderItem>();

            //foreach (var item in Globals.FullFoodMenuList)
            //{
            //    tempOrderList.Add(new OrderItem(item.id, item.dishName, item.koreanName, item.description, item.price, item.foodCategory, 1));
            //}

            //foodItemsViewModel.OrderedItems = tempOrderList;

            //if (foodItemsViewModel.OrderedItems == null)
            //{

            //}

            return View(foodItemsViewModel);
        }


        public async Task<IActionResult> _FoodOrderPartial()
        {
            //Globals.FullFoodMenuList = await _menuEndpointService.GetFoodItemsFromCloud();

            //if (Globals.FoodItemsList == null)
            //{
            //    return null;
            //}


            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();
            //List<OrderItem> tempOrderList = new List<OrderItem>();

            //foreach (var item in Globals.FoodItemsList)
            //{
            //    tempOrderList.Add(new OrderItem(item.id,  item.dishName,  item.koreanName, item.description, item.price, item.foodCategory,  1 ));
            //}

            if (Globals.CartItemsList != null)
            {
                foodItemsViewModel.OrderedItems = Globals.CartItemsList;
            }


            return View(foodItemsViewModel);
        }

        public IActionResult AddToCart(string itemIdToAdd)
        {
            // Add itemToAdd to the cart

            OrderItem requestedItem = null;

            if (!string.IsNullOrWhiteSpace(itemIdToAdd))
            {
                int foodItemId, requestedItemId;

                int.TryParse(itemIdToAdd, out requestedItemId);

                foreach (var foodCategory in Globals.FoodCategoriesList)
                {
                    foreach (var foodItem in foodCategory.FoodItems)
                    {
                        int.TryParse(foodItem.id, out foodItemId);

                        if (foodItemId == requestedItemId)
                        {
                            requestedItem = new OrderItem(
                                foodItem.id,
                                foodItem.dishName,
                                foodItem.koreanName,
                                foodItem.description,
                                foodItem.price,
                                foodItem.foodCategory,
                                    1
                                );

                            break;
                        }
                    }

                }


     //           Globals.CurrentCategory = requestedItem.categoryName;


                FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();



                Globals.CartItemsList.Add(requestedItem);

                //Globals.CartItemsList.Add(new OrderItem(requestedItem.id, requestedItem.dishName, requestedItem.koreanName, requestedItem.description, requestedItem.price, requestedItem.categoryName, 1));

                double tempPrice = 0;

                double.TryParse(requestedItem.price, out tempPrice);

                Globals.OrderTotalCost += tempPrice;

                //foodItemsViewModel.OrderTotalCost = Globals.OrderTotalCost; 
            }

            //  return ViewComponent("TakeOutMenu", "Menu");

            return RedirectToAction("TakeOutMenu", "Menu");

        }

        public IActionResult DeleteFromCart(string itemIdToDelete)
        {
            // Add itemToAdd to the cart

            FoodMenu.FoodItem requestedItem = null;

            if (!string.IsNullOrWhiteSpace(itemIdToDelete))
            {
                int foodItemId, deletedItemId;

                int.TryParse(itemIdToDelete, out deletedItemId);

                foreach (var item in Globals.CartItemsList)
                {
                    int.TryParse(item.id, out foodItemId);

                    if (foodItemId == deletedItemId)
                    {
                        Globals.CartItemsList.Remove(item);

                        double tempPrice = 0;

                        double.TryParse(item.price, out tempPrice);

                        Globals.OrderTotalCost -= tempPrice;

                        break;
                    }
                }

            }

            return RedirectToAction("TakeOutMenu", "Menu");

        }
    }
}
