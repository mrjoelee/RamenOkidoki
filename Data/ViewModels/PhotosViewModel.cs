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

          CarouselImages = new List<CarouselImage>(DummyData.GetCarouselImages());
         

          List<string> tempPaths = new List<string>();
          foreach (var pic in CarouselImages)
          {
              tempPaths.Add("@Url.Content" + pic.ImagePath);
          }

          PhotoJson = JsonSerializer.Serialize(tempPaths);
        }
    }
}
