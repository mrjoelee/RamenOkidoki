using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RamenOkiDoki.Services;

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
            
            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.OrderedItems = Globals.CartItemsList;

            foodItemsViewModel.OrderTotalCost = string.Format("{0:C}",Globals.OrderTotalCost);
            
            return View("FoodOrderCart", foodItemsViewModel);
        }
    }
}
