using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Models.FoodMenus;
using Data.ViewModels;
using Microsoft.AspNetCore.Routing;

namespace RamenOkiDoki.Controllers
{
    public class CartController : Controller
    {


        public CartController()
        {

            // Globals.CartItemList = new List<OrderItem>();
        }

        public async Task<IActionResult> Index()
        {

            FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

            return View(foodMenuViewModel);
        }


        public async Task<IActionResult> _FoodOrderPartial()
        {

            FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

            if (Globals.CartItemList != null)
            {
                foodMenuViewModel.CurrentTakeoutOrder.FoodOrderItemList = Globals.CartItemList;
            }


            return View(foodMenuViewModel);
        }


        //method to add item to the cart
        public IActionResult AddToCart(int itemIdToAdd)
        {
            decimal tempPrice = 0.00m;
            // Add itemToAdd to the cart

            bool itemExists = false;

            OrderItem requestedItem = null;

            int currentCategoryId = 0;

            if (itemIdToAdd > 0)
            {
                foreach (var item in Globals.CartItemList)
                {
                    if (item.Id == itemIdToAdd)
                    {
                        itemExists = true;

                        item.quantity++;

                        tempPrice = 0.00m;

                        decimal.TryParse(item.price, out tempPrice);

                        Globals.OrderSubTotalCost += tempPrice;

                        currentCategoryId = item.foodCategoryId;

                        break;
                    }
                }

                if (!itemExists)
                {
                    foreach (var foodItem in Globals.FoodItemList)
                    {
                        if (foodItem.Id == itemIdToAdd)
                        {
                            requestedItem = new OrderItem(
                                foodItem.Id,
                                foodItem.dishName,
                                foodItem.description,
                                foodItem.price,
                                foodItem.foodCategory,
                                foodItem.foodCategoryId,
                                1
                            );

                            currentCategoryId = requestedItem.foodCategoryId;

                            break;
                        }

                    }

                    Globals.CartItemList.Add(requestedItem);
                    tempPrice = 0;
                    decimal.TryParse(requestedItem.price, out tempPrice);


                    Globals.OrderSubTotalCost += tempPrice;

               //     FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

                }

                Globals.OrderTotalItems++;

            }
            return RedirectToAction("TakeOutMenu", "Menu", new { id = currentCategoryId.ToString() });
            //return RedirectToAction("TakeOutMenu", "Menu", currentCategoryId);
        }



        //Method to delete item from the cart
        public IActionResult DeleteFromCart(string itemIdToDelete)
        {

            FoodItem requestedItem = null;

            if (!string.IsNullOrWhiteSpace(itemIdToDelete))
            {
                int foodItemId, deletedItemId;

                int.TryParse(itemIdToDelete, out deletedItemId);

                foreach (var item in Globals.CartItemList)
                {
                    // int.TryParse(item.id, out foodItemId);

                    if (item.Id == deletedItemId)
                    {
                        Globals.OrderTotalItems -= item.quantity;

                        if ( Globals.OrderTotalItems < 0)
                        {
                            Globals.OrderTotalItems = 0;
                        }

                        Globals.CartItemList.Remove(item);

                        decimal tempPrice = 0.00m;

                        decimal.TryParse(item.price, out tempPrice);

                        Globals.OrderSubTotalCost -= tempPrice;

                        break;
                    }
                }

            }

            return RedirectToAction("TakeOutMenu", "Menu");

        }

        //Method to decrease item on the  cart
        public IActionResult DecreaseQuantity(string itemId)
        {
            decimal tempPrice = 0.00m;

            FoodItem requestedItem = null;

            if (!string.IsNullOrWhiteSpace(itemId))
            {
                int foodItemId, decreasedItemId;

                int.TryParse(itemId, out decreasedItemId);

                foreach (var item in Globals.CartItemList)
                {
                    //  int.TryParse(item.id, out foodItemId);

                    if (item.Id == decreasedItemId)
                    {
                        item.quantity--;

                        tempPrice = 0;

                        decimal.TryParse(item.price, out tempPrice);

                        Globals.OrderSubTotalCost -= tempPrice;

                        break;
                    }
                }

                foreach (var item in Globals.CartItemList)
                {
                    if (item.quantity < 1)
                    {
                        Globals.CartItemList.Remove(item);

                        tempPrice = 0;

                        decimal.TryParse(item.price, out tempPrice);

                        Globals.OrderSubTotalCost -= tempPrice;

                        break;
                    }

                    continue;
                }

                Globals.OrderTotalItems--;

                if (Globals.OrderTotalItems < 0)
                {
                    Globals.OrderTotalItems = 0;
                }

            }
            return RedirectToAction("TakeOutMenu", "Menu");

        }

        //Method to increase item on the cart 
        public IActionResult IncreaseQuantity(string itemId)
        {
            FoodItem requestedItem = null;

            if (!string.IsNullOrWhiteSpace(itemId))
            {
                int foodItemId, increasedItemId;

                int.TryParse(itemId, out increasedItemId);

                foreach (var item in Globals.CartItemList)
                {
                    // int.TryParse(item.id, out foodItemId);

                    if (item.Id == increasedItemId)
                    {
                        //Globals.CartItemList.Add(item);
                        item.quantity++;

                        decimal tempPrice = 0;

                        decimal.TryParse(item.price, out tempPrice);

                        Globals.OrderSubTotalCost += tempPrice;

                        Globals.OrderTotalItems++;

                        break;
                    }
                    continue;
                }
            }

            return RedirectToAction("TakeOutMenu", "Menu");
        }

        public IActionResult CheckOut()
        {
            FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();


            foodMenuViewModel.CurrentTakeoutOrder.FoodOrderItemList = Globals.CartItemList;

            //foodMenuViewModel.CurrentTakeoutOrder.OrderSubTotalCost = string.Format("{0:C}", Globals.OrderSubTotalCost);

            //foodMenuViewModel.CurrentTakeoutOrder.TotalSalesTax = string.Format("{0:C}", Globals.TotalSalesTax);

            //foodMenuViewModel.CurrentTakeoutOrder.OrderTotalCost = string.Format("{0:C}", Globals.OrderTotalCost);



            return View(foodMenuViewModel);
        }

    }
}
