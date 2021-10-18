using System.Threading.Tasks;

using Data.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace RamenOkiDoki.ViewComponents
{
    public class GoogleMapViewComponent : ViewComponent
    {
        public GoogleMapViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            GoogleMapViewModel googleMapViewModel = new GoogleMapViewModel();

            return View("GoogleMap", googleMapViewModel);
        }
    }
}
