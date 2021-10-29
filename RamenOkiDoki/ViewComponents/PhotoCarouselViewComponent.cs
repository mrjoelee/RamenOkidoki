using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        System.Threading.Timer timer;
        public PhotosViewModel photosViewModel;

        public PhotoCarouselViewComponent()
        {
              photosViewModel = new PhotosViewModel();

            //ObservableCollection<CarouselImage> carouselImages = new ObservableCollection<CarouselImage>();

            //carouselImages = GetCarouselImages();

            //CarouselImage carouselImage = carouselImages[0];

            //await InvokeAsync(carouselImage);

            //foreach (var carouselImage in carouselImages)
            //{
            //    timer = new System.Threading.Timer(async _ => { await InvokeAsync(carouselImage); }, null, 0, 1000);
            //}
        }

        public async Task<IViewComponentResult> InvokeAsync()//string path, string name)
        {
            //photosViewModel.CurrentCarouselImage = new CarouselImage();
            //photosViewModel.CurrentCarouselImage.ImagePath = path;
            //photosViewModel.CurrentCarouselImage.ImageName = name;

           // ObservableCollection<CarouselImage> carouselImages = new ObservableCollection<CarouselImage>();
          //  carouselImages = GetCarouselImages();

            photosViewModel.CarouselImages = new List<CarouselImage>(GetCarouselImages());

         //   Random rand = new Random();
          //  int imageNumber = rand.Next(0, carouselImages.Count - 1);

         //   photosViewModel.CurrentCarouselImage = carouselImages[imageNumber];


            return View("PhotoCarousel", photosViewModel);
        }

        public ObservableCollection<CarouselImage> GetCarouselImages()
        {
            return new ObservableCollection<CarouselImage>()
            {
                new CarouselImage()
                    { ImageName = "Ru Okidoki Ramen", ImagePath = "/images/GalleryImages/Ru_okidoki.jpg" },
                new CarouselImage()
                    { ImageName = "Mentaiko Udon", ImagePath = "/images/GalleryImages/MentaikoUdon.jpg" },
                new CarouselImage()
                {
                    ImageName = "Okidoki X Lim's Chicken",
                    ImagePath = "/images/GalleryImages/okidoki_x_lims chicken.jpg"
                },
                new CarouselImage() { ImageName = "Onigiri", ImagePath = "/images/GalleryImages/Onigiri.jpg" },
                new CarouselImage() { ImageName = "Pork Bun", ImagePath = "/images/GalleryImages/Pork_Bun.jpg" },
                new CarouselImage() { ImageName = "Shoyu Ramen", ImagePath = "/images/GalleryImages/Shoyu_Ramen.jpg" },
                new CarouselImage()
                    { ImageName = "Spicy Hiyashi", ImagePath = "/images/GalleryImages/spicy_hiyashi.jpg" },
                new CarouselImage() { ImageName = "Spicy Miso", ImagePath = "/images/GalleryImages/Spicy_Miso.jpg" },
                new CarouselImage()
                    { ImageName = "Spicy Tonkotsu", ImagePath = "/images/GalleryImages/Spicy_Tonkotsu.jpg" },
                new CarouselImage() { ImageName = "Takoyaki", ImagePath = "/images/GalleryImages/Takoyaki.jpg" },
                new CarouselImage()
                    { ImageName = "Tonkotsu Ramen", ImagePath = "/images/GalleryImages/Tonkotsu_Ramen.jpg" }
            };
        }
    }
}
