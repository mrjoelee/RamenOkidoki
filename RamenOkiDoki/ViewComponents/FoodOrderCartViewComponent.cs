using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RamenOkiDoki.ViewComponents
{
    public class FoodOrderCartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.OrderedItemList = Globals.CartItemList;

            foodItemsViewModel.OrderSubTotalCost = string.Format("{0:C}",Globals.OrderSubTotalCost);
            
            return View("FoodOrderCart", foodItemsViewModel);
        }
    }
}
