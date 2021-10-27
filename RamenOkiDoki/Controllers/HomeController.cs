using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.ViewModels;
using Microsoft.CodeAnalysis.CSharp;
using RamenOkiDoki.Helpers;

namespace RamenOkiDoki.Controllers
{
    public class HomeController : Controller
    {
        private HomePageViewModel homePageViewModel;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            homePageViewModel = new HomePageViewModel();
        }

        public IActionResult Index()
        {

            return View(homePageViewModel);
        }

        [HttpPost, ActionName("Index")]
        public IActionResult SubmitReview(Review newReview)
        {
            newReview.ReviewDate = DateTime.Today.ToString("MMMM yyyy");

            homePageViewModel.Reviews.Add(newReview);

            return View(homePageViewModel);
        }



        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
