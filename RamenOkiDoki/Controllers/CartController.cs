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
                foodMenuViewModel.OrderedItemList = Globals.CartItemList;
            }


            return View(foodMenuViewModel);
        }

   
        //method to add item to the cart
        public IActionResult AddToCart(string itemIdToAdd)
        {
            decimal tempPrice = 0.00m;
            // Add itemToAdd to the cart

            bool itemExists = false;

            OrderItem requestedItem = null;

            int foodItemId, requestedItemId;

            int.TryParse(itemIdToAdd, out requestedItemId);

            if (!string.IsNullOrWhiteSpace(itemIdToAdd))
            {


                foreach (var item in Globals.CartItemList)
                {
                   // int.TryParse(item.Id, out foodItemId);

                    if (item.Id == requestedItemId)
                    {
                        itemExists = true;

                        item.quantity++;

                        tempPrice = 0.00m;

                        decimal.TryParse(item.price, out tempPrice);

                        Globals.OrderSubTotalCost += tempPrice;


                        break;
                    }
                }

                if (!itemExists)
                {

                    foreach (var foodCategory in Globals.FoodCategoryList)
                    {
                        foreach (var foodItem in foodCategory.FoodItemList)
                        {
                           // int.TryParse(foodItem.id, out foodItemId);

                            if (foodItem.Id == requestedItemId)
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

                                break;
                            }

                        }
                    }

                    Globals.CartItemList.Add(requestedItem);
                    tempPrice = 0;
                    decimal.TryParse(requestedItem.price, out tempPrice);


                    Globals.OrderSubTotalCost += tempPrice;

                    FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

                    return RedirectToAction("TakeOutMenu", new RouteValueDictionary(
                new
                {
                    controller = "Menu",
                    action = "TakeOutMenu",
                    category = requestedItem.foodCategory
                }));
                }

                
            }

            return RedirectToAction("TakeOutMenu", "Menu");
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


            foodMenuViewModel.OrderedItemList = Globals.CartItemList;

            foodMenuViewModel.OrderSubTotalCost = string.Format("{0:C}", Globals.OrderSubTotalCost);

            foodMenuViewModel.OrderTotalSalesTax = string.Format("{0:C}", Globals.TotalSalesTax);

            foodMenuViewModel.OrderTotalCost = string.Format("{0:C}", Globals.OrderTotalCost);



            return View(foodMenuViewModel);
        }

    }
}
