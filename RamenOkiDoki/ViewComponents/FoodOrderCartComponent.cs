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
            
            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.OrderedItems = Globals.CartItems;

            foodItemsViewModel.OrderTotalCost = string.Format("{0:C}",Globals.OrderTotalCost);
            
            return View("FoodOrderCart", foodItemsViewModel);
        }
    }
}
