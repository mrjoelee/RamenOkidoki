using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Data.Models;
using Data.Models.FoodMenus;

namespace Data.ViewModels
{
    public class PhotosViewModel
    {
        public List<CarouselImage> CarouselImages { get; set; }

        public CarouselImage CurrentCarouselImage;

        public string PhotoJson { get; set; }

        public PhotosViewModel()
        {
            //  Image = new string("/images/GalleryImages/Ru_okidoki.jpg");

          CurrentCarouselImage = new CarouselImage();

          CarouselImages = new List<CarouselImage>()
          {
              new CarouselImage(){ImageName = "Ru Okidoki Ramen", ImagePath = "/images/GalleryImages/Ru_okidoki.jpg"},
              new CarouselImage(){ImageName = "Mentaiko Udon", ImagePath = "/images/GalleryImages/MentaikoUdon.jpg"},
              new CarouselImage(){ImageName = "Okidoki X Lim's Chicken", ImagePath = "/images/GalleryImages/okidoki_x_lims chicken.jpg"},
              new CarouselImage(){ImageName = "Onigiri", ImagePath = "/images/GalleryImages/Onigiri.jpg"},
              new CarouselImage(){ImageName = "Pork Bun", ImagePath = "/images/GalleryImages/Pork_Bun.jpg"},
              new CarouselImage(){ImageName = "Shoyu Ramen", ImagePath = "/images/GalleryImages/Shoyu_Ramen.jpg"},
              new CarouselImage(){ImageName = "Spicy Hiyashi", ImagePath = "/images/GalleryImages/spicy_hiyashi.jpg"},
              new CarouselImage(){ImageName = "Spicy Miso", ImagePath = "/images/GalleryImages/Spicy_Miso.jpg"},
              new CarouselImage(){ImageName = "Spicy Tonkotsu", ImagePath = "/images/GalleryImages/Spicy_Tonkotsu.jpg"},
              new CarouselImage(){ImageName = "Takoyaki", ImagePath = "/images/GalleryImages/Takoyaki.jpg"},
              new CarouselImage(){ImageName = "Tonkotsu Ramen", ImagePath = "/images/GalleryImages/Tonkotsu_Ramen.jpg"}
          };

          List<string> tempPaths = new List<string>();
          foreach (var pic in CarouselImages)
          {
              tempPaths.Add("@Url.Content" + pic.ImagePath);
          }

          PhotoJson = JsonSerializer.Serialize(tempPaths);
        }
    }
}
