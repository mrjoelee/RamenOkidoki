using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using RamenOkiDoki.Services;
using RamenOkiDoki.ViewModels;

namespace RamenOkiDoki.Controllers
{
    public class CartController : Controller
    {
        private MenuEndpointService _menuEndpointService { get; set; }

        public CartController(MenuEndpointService menuEndpointService)
        {
            _menuEndpointService = menuEndpointService;
            // Globals.CartItems = new List<OrderItem>();
        }

        public async Task<IActionResult> Index()
        {
            Globals.FoodItems = await _menuEndpointService.GetFoodItemsFromCloud();

            if (Globals.FoodItems == null)
            {
                return null;
            }


            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();
            List<OrderItem> tempOrderList = new List<OrderItem>();

            foreach (var item in Globals.FoodItems)
            {
                tempOrderList.Add(
                    new OrderItem() { id = item.id, dishName = item.dishName, koreanName = item.koreanName, price = item.price, quantity = 1 });
            }

            foodItemsViewModel.OrderedItems = tempOrderList;

            if (foodItemsViewModel.OrderedItems == null)
            {

            }

            return View(foodItemsViewModel);
        }


        public async Task<IActionResult> _FoodOrderPartial()
        {
            Globals.FoodItems = await _menuEndpointService.GetFoodItemsFromCloud();

            if (Globals.FoodItems == null)
            {
                return null;
            }


            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();
            List<OrderItem> tempOrderList = new List<OrderItem>();

            foreach (var item in Globals.FoodItems)
            {
                tempOrderList.Add(
                    new OrderItem() { id = item.id, dishName = item.dishName, koreanName = item.koreanName, price = item.price, quantity = 1 });
            }

            foodItemsViewModel.OrderedItems = tempOrderList;

            if (foodItemsViewModel.OrderedItems == null)
            {

            }

            return View(foodItemsViewModel);
        }

        public IActionResult AddToCart(string itemIdToAdd)
        {
            // Add itemToAdd to the cart

            FoodItem requestedItem = null;

            if (!string.IsNullOrWhiteSpace(itemIdToAdd))
            {
                int foodItemId, requestedItemId;

                int.TryParse(itemIdToAdd, out requestedItemId);

                foreach (var item in Globals.FoodItems)
                {
                    int.TryParse(item.id, out foodItemId);

                    if (foodItemId == requestedItemId)
                    {
                        requestedItem = item;
                    }
                }


                Globals.CurrentCategory = requestedItem.categoryName;


                FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();



                Globals.CartItems.Add(new OrderItem() { id = requestedItem.id, dishName = requestedItem.dishName, koreanName = requestedItem.koreanName, price = requestedItem.price, quantity = 1 });

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

            FoodItem requestedItem = null;

            if (!string.IsNullOrWhiteSpace(itemIdToDelete))
            {
                int foodItemId, deletedItemId;

                int.TryParse(itemIdToDelete, out deletedItemId);

                foreach (var item in Globals.CartItems)
                {
                    int.TryParse(item.id, out foodItemId);

                    if (foodItemId == deletedItemId)
                    {
                        Globals.CartItems.Remove(item);

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
