using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.ViewModels
{
    public class PhotosViewModel
    {
        public List<CarouselImage> CarouselImages { get; set; }

        public CarouselImage CurrentCarouselImage;

        public PhotosViewModel()
        {
            //  Image = new string("/images/GalleryImages/Ru_okidoki.jpg");

          CurrentCarouselImage = new CarouselImage(string.Empty, string.Empty);

          CarouselImages = new List<CarouselImage>()
          {
              new CarouselImage("Ru Okidoki Ramen", "/images/GalleryImages/Ru_okidoki.jpg"),
              new CarouselImage("Mentaiko Udon", "/images/GalleryImages/MentaikoUdon.jpg"),
              new CarouselImage("Okidoki X Lim's Chicken", "/images/GalleryImages/okidoki_x_lims chicken.jpg"),
              new CarouselImage("Onigiri", "/images/GalleryImages/Onigiri.jpg"),
              new CarouselImage("Pork Bun", "/images/GalleryImages/Pork_Bun.jpg"),
              new CarouselImage("Shoyu Ramen", "/images/GalleryImages/Shoyu_Ramen.jpg"),
              new CarouselImage("Spicy Hiyashi", "/images/GalleryImages/spicy_hiyashi.jpg"),
              new CarouselImage("Spicy Miso", "/images/GalleryImages/Spicy_Miso.jpg"),
              new CarouselImage("Spicy Tonkotsu", "/images/GalleryImages/Spicy_Tonkotsu.jpg"),
              new CarouselImage("Takoyaki", "/images/GalleryImages/Takoyaki.jpg"),
              new CarouselImage("Tonkotsu Ramen", "/images/GalleryImages/Tonkotsu_Ramen.jpg")
          };
        }
    }
}
