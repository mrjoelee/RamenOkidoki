using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class PhotosViewModel
    {
        public string Image { get; set; }

        public PhotosViewModel()
        {
            Image = new string("/images/GalleryImages/Ru_okidoki.jpg");
        }
    }
}
