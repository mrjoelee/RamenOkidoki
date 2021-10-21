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

        public PhotosViewModel()
        {
          //  Image = new string("/images/GalleryImages/Ru_okidoki.jpg");

          CarouselImages = new List<CarouselImage>()
          {
              new CarouselImage(),

          };
        }
    }
}
