using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using RamenOkiDoki.Models;
using RamenOkiDoki.Services;
using RamenOkiDoki.ViewModels;

namespace RamenOkiDoki.ViewComponents
{
    public class FoodOrderCartViewComponent : ViewComponent
    {
        private MenuEndpointService _menuEndpointService { get; set; }
        public FoodOrderCartViewComponent(MenuEndpointService menuEndpointService)
        {
            _menuEndpointService = menuEndpointService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
            return View("FoodOrderCart", foodItemsViewModel);
        }
    }
}
