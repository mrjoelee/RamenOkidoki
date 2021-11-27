using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Data.Models;
using Data.Models.FoodMenus;
using Data.Models.TakeOuts;
using Data.Repositories;
using Data.ViewModels;
using Microsoft.AspNetCore.Routing;

namespace RamenOkiDoki.Controllers
{
    public class CartController : Controller
    {
        private DatabaseRepository _databaseRepository;

        public CartController(DatabaseRepository databaseRepository)
        {
            if (Globals.GlobalFoodOrder == null)
            {
                Globals.GlobalFoodOrder = new FoodOrder();
            }

            // Globals.CartItemList = new List<OrderItem>();

            _databaseRepository = databaseRepository;
        }

        public async Task<IActionResult> Index()
        {

            FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

            return View(foodMenuViewModel);
        }


        public IActionResult _FoodOrderPartial()
        {

            FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

            if (Globals.GlobalFoodOrder.FoodOrderItemList != null)
            {
                foodMenuViewModel.CurrentTakeoutOrder.FoodOrderItemList = Globals.GlobalFoodOrder.FoodOrderItemList;
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

            // itemToAdd is FoodItem id from takeout menu
            if (itemIdToAdd > 0)
            {
                foreach (var item in Globals.GlobalFoodOrder.FoodOrderItemList)
                {
                    // Is this item already already in the cart?

                    if (item.OrderItemId == itemIdToAdd)
                    {
                        itemExists = true;

                        // Just increase the quanity without entering duplicate quantity

                        item.quantity++;

                        Globals.GlobalFoodOrder.OrderSubTotalCost += item.price;

                        // Get CategoryId from globals foodlist with linq

                        //  currentCategoryId = Globals.FoodItemList.Where(i => i.Id(x => x == 1));//(itemIdToAdd));;

                        foreach (var foodItem in Globals.FoodItemList)
                        {
                            if (foodItem.Id == itemIdToAdd)
                            {
                                currentCategoryId = foodItem.foodCategoryId;
                            }
                        }

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
                                foodItem.price
                            );

                            currentCategoryId = foodItem.foodCategoryId;

                            break;
                        }

                    }

                    Globals.GlobalFoodOrder.FoodOrderItemList.Add(requestedItem);

                    Globals.GlobalFoodOrder.OrderSubTotalCost += requestedItem.price;

                    //     FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

                }

                Globals.GlobalFoodOrder.OrderTotalItems++;

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

                foreach (var item in Globals.GlobalFoodOrder.FoodOrderItemList)
                {
                    // int.TryParse(item.id, out foodItemId);

                    if (item.OrderItemId == deletedItemId)
                    {
                        Globals.GlobalFoodOrder.OrderTotalItems -= item.quantity;

                        if (Globals.GlobalFoodOrder.OrderTotalItems < 0)
                        {
                            Globals.GlobalFoodOrder.OrderTotalItems = 0;
                        }

                        Globals.GlobalFoodOrder.FoodOrderItemList.Remove(item);

                        Globals.GlobalFoodOrder.OrderSubTotalCost -= item.price;

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

                foreach (var item in Globals.GlobalFoodOrder.FoodOrderItemList)
                {
                    //  int.TryParse(item.id, out foodItemId);

                    if (item.OrderItemId == decreasedItemId)
                    {
                        item.quantity--;

                        Globals.GlobalFoodOrder.OrderSubTotalCost -= item.price;

                        break;
                    }
                }

                foreach (var item in Globals.GlobalFoodOrder.FoodOrderItemList)
                {
                    if (item.quantity < 1)
                    {
                        Globals.GlobalFoodOrder.FoodOrderItemList.Remove(item);

                        Globals.GlobalFoodOrder.OrderSubTotalCost -= item.price;

                        break;
                    }

                    continue;
                }

                Globals.GlobalFoodOrder.OrderTotalItems--;

                if (Globals.GlobalFoodOrder.OrderTotalItems < 0)
                {
                    Globals.GlobalFoodOrder.OrderTotalItems = 0;
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

                foreach (var item in Globals.GlobalFoodOrder.FoodOrderItemList)
                {
                    // int.TryParse(item.id, out foodItemId);

                    if (item.OrderItemId == increasedItemId)
                    {
                        //Globals.CartItemList.Add(item);
                        item.quantity++;

                        Globals.GlobalFoodOrder.OrderSubTotalCost += item.price;

                        Globals.GlobalFoodOrder.OrderTotalItems++;

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

            foodMenuViewModel.CurrentTakeoutOrder.FoodOrderItemList = Globals.GlobalFoodOrder.FoodOrderItemList;

            foodMenuViewModel.CurrentTakeoutOrder.OrderSubTotalCost = Globals.GlobalFoodOrder.OrderSubTotalCost;


            //_databaseRepository.AddRestaurantData(foodMenuViewModel.CurrentTakeoutOrder);

            //foodMenuViewModel.CurrentTakeoutOrder.TotalSalesTax = string.Format("{0:C}", Globals.TotalSalesTax);

            //foodMenuViewModel.CurrentTakeoutOrder.OrderTotalCost = string.Format("{0:C}", Globals.OrderTotalCost);



            return View(foodMenuViewModel);
        }

        public async Task<IActionResult> PayForOrder(FoodMenuViewModel fvm)
        {

            FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

            foodMenuViewModel.CurrentTakeoutOrder = Globals.GlobalFoodOrder;

            //foodMenuViewModel.CurrentTakeoutOrder.OrderTotalItems = Globals.GlobalFoodOrder.OrderTotalItems;

            //foodMenuViewModel.CurrentTakeoutOrder.FoodOrderItemList = Globals.GlobalFoodOrder.FoodOrderItemList;

            //foodMenuViewModel.CurrentTakeoutOrder.OrderSubTotalCost = Globals.GlobalFoodOrder.OrderSubTotalCost;

            if (Globals.UserSignedIn)
            {
                foodMenuViewModel.CurrentTakeoutOrder.RegisteredCustomer = Globals.SignedInCustomer;
            }
            else
            {
                foodMenuViewModel.CurrentTakeoutOrder.RegisteredCustomer.Id = 1;
                foodMenuViewModel.CurrentTakeoutOrder.RegisteredCustomer.UserName = "Guest";
                foodMenuViewModel.CurrentTakeoutOrder.NonRegisteredCustomerLastName = fvm.CurrentTakeoutOrder.NonRegisteredCustomerLastName;
            }

            _databaseRepository.AddRestaurantData(foodMenuViewModel.CurrentTakeoutOrder);

            return RedirectToAction("TakeOutMenu", "Menu");
        }

    }
}
