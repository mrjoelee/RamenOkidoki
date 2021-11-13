using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamenOkiDoki.Controllers
{
    public class MyAccount : Controller
    {
        public IActionResult Index()
        {
            return View();
        }  
        
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }  
        
        public IActionResult SignOut()
        {
            return View();
        }
    }

}
