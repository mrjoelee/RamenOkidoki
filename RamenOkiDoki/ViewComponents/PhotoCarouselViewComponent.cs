using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

using Data.Models;
using Data.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace RamenOkiDoki.ViewComponents
{
    public class PhotoCarouselViewComponent : ViewComponent
    {
        public System.Threading.Timer Timer;
        public PhotosViewModel photosViewModel;

        public PhotoCarouselViewComponent()
        {
            photosViewModel = new PhotosViewModel();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //  photosViewModel.CurrentCarouselImage = new string("/images/GalleryImages/Spicy_Miso.jpg");


            //foreach (var carouselImage in photosViewModel.CarouselImages)
            //{
            //    photosViewModel.CurrentCarouselImage = new CarouselImage(carouselImage.ImageName, carouselImage.ImagePath);

            //    await Task.Delay(TimeSpan.FromSeconds(3));

            //    return View("PhotoCarousel", photosViewModel);
            //}

                return View("PhotoCarousel", photosViewModel);
        }


    }
}
