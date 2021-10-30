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
        }

        public async Task<IViewComponentResult> InvokeAsync()//string path, string name)
        {
        return View("PhotoCarousel", photosViewModel);
        }
    }
}
