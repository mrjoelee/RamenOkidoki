using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace RamenOkiDoki.ViewComponents
{
    public class FoodOrderCartViewComponent : ViewComponent
    {
        public FoodOrderCartViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           // ViewBag.CurrentCity = await GetCity(cityName);
            return View("FoodOrderCart");
        }
    }
}
