using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RamenOkiDoki.ViewComponents
{
    public class PhotoCarouselViewComponent : ViewComponent
    {
        public PhotoCarouselViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        { 
            PhotosViewModel photosViewModel = new PhotosViewModel();

            photosViewModel.Image = new string("/images/GalleryImages/Spicy_Miso.jpg");

            return View("PhotoCarousel", photosViewModel);
        }
    }
}
