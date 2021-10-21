using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Data.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace RamenOkiDoki.ViewComponents
{
    public class PhotoCarouselViewComponent : ViewComponent
    {
        public PhotosViewModel photosViewModel;

        public PhotoCarouselViewComponent()
        {
            photosViewModel = new PhotosViewModel();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
          //  photosViewModel.CurrentCarouselImage = new string("/images/GalleryImages/Spicy_Miso.jpg");

            StartCarouselShow();

            return View("PhotoCarousel", photosViewModel);
        }

        private void StartCarouselShow()
        {
            System.Timers.Timer(3000) =>
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (var carouselImage in photosViewModel.CarouselImages)
                    {
                        photosViewModel = new PhotosViewModel(carouselImage.ImageName, carouselImage.ImagePath);
                    }
                });

                return View("PhotoCarousel", photosViewModel);
            });
        }
    }
}
