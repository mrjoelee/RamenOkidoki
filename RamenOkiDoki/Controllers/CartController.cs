using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Models.FoodMenus;
using Data.ViewModels;
using DataServices.Services;
using Microsoft.AspNetCore.Routing;

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

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            return View(foodItemsViewModel);
        }


        public async Task<IActionResult> _FoodOrderPartial()
        {

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

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

                foreach (var item in Globals.CartItemsList)
                {
                    int.TryParse(item.id, out foodItemId);

                    if (foodItemId == requestedItemId)
                    {
                        item.quantity++;

                        double tempPrice = 0.00;

                        double.TryParse(item.price, out tempPrice);

                        Globals.OrderSubTotalCost += tempPrice;

                        break;
                    }
                }

                else
                {
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
                                    foodItem.description,
                                    foodItem.price,
                                    foodItem.foodCategory,
                                    foodItem.foodCategoryId,
                                    1
                                );

                                break;
                            }

                        }
                    }
                }


                FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

                Globals.CartItemsList.Add(requestedItem);

                //Globals.CartItemsList.Add(new OrderItem(requestedItem.id, requestedItem.dishName, requestedItem.description, requestedItem.price, requestedItem.categoryName, 1));

                double tempPrice = 0;

                double.TryParse(requestedItem.price, out tempPrice);

                Globals.OrderSubTotalCost += tempPrice;

            }

            return RedirectToAction("TakeOutMenu", new RouteValueDictionary(
                new
                {
                    controller = "Menu",
                    action = "TakeOutMenu",
                    category = requestedItem.foodCategory
                }));

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

                        Globals.OrderSubTotalCost -= tempPrice;

                        break;
                    }
                }

            }

            return RedirectToAction("TakeOutMenu", "Menu");

        }

        public IActionResult DecreaseQuantity(string itemId)
        {
            FoodMenu.FoodItem requestedItem = null;

            if (!string.IsNullOrWhiteSpace(itemId))
            {
                int foodItemId, decreasedItemId;

                int.TryParse(itemId, out decreasedItemId);

                foreach (var item in Globals.CartItemsList)
                {
                    int.TryParse(item.id, out foodItemId);

                    if (foodItemId == decreasedItemId)
                    {
                        Globals.CartItemsList.Remove(item);

                        double tempPrice = 0;

                        double.TryParse(item.price, out tempPrice);

                        Globals.OrderSubTotalCost -= tempPrice;

                        break;
                    }
                    continue;
                }

            }
            return RedirectToAction("TakeOutMenu", "Menu");

        }

        public IActionResult IncreaseQuantity(string itemId)
        {
            FoodMenu.FoodItem requestedItem = null;

            if (!string.IsNullOrWhiteSpace(itemId))
            {
                int foodItemId, increasedItemId;

                int.TryParse(itemId, out increasedItemId);

                foreach (var item in Globals.CartItemsList)
                {
                    int.TryParse(item.id, out foodItemId);

                    if (foodItemId == increasedItemId)
                    {
                        //Globals.CartItemsList.Add(item);
                        item.quantity++;

                        double tempPrice = 0;

                        double.TryParse(item.price, out tempPrice);

                        Globals.OrderSubTotalCost += tempPrice;

                        break;
                    }
                    continue;
                }
            }

            return RedirectToAction("TakeOutMenu", "Menu");
        }

        public IActionResult CheckOut()
        {
            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();


            foodItemsViewModel.OrderedItems = Globals.CartItemsList;

            foodItemsViewModel.OrderSubTotalCost = string.Format("{0:C}", Globals.OrderSubTotalCost);

            foodItemsViewModel.OrderTotalSalesTax = string.Format("{0:C}", Globals.TotalSalesTax);

            foodItemsViewModel.OrderTotalCost = string.Format("{0:C}", Globals.OrderTotalCost);



            return View(foodItemsViewModel);
        }

    }
}
