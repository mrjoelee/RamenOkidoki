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
        public PhotosViewModel photosViewModel;

        public PhotoCarouselViewComponent()
        {
            photosViewModel = new PhotosViewModel();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {


            photosViewModel.Image = new string("/images/GalleryImages/Spicy_Miso.jpg");

            StartCarouselShow();

            return View("PhotoCarousel", photosViewModel);
        }

        private void StartCarouselShow()
        {

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                Device.InvokeOnMainThreadAsync(() =>
                {
                    foreach (var carouselImage in CarouselImages)
                    {
                        photosViewModel = new PhotosViewModel(carouselImage.ImageName, carouselImage.ImagePath);
                    }
                });

                return View("PhotoCarousel", photosViewModel);
            });
        }
    }
}
