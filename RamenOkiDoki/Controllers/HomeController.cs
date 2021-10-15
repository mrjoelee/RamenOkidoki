using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RamenOkiDoki.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using RamenOkiDoki.Helpers;
using RamenOkiDoki.Services;
using RamenOkiDoki.ViewModels;

namespace RamenOkiDoki.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Globals.CartItems = new List<OrderItem>();
            Globals.OrderTotalCost = 0.00;
        }

        public IActionResult Index()
        {
            return View();
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
