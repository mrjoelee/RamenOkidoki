using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Models.User;

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

        [Route("SignIn")]
        public IActionResult LogOut()
        {

            return View();
        }

        public IActionResult SignUserIn()
        {
            Globals.UserSignedIn = true;


            // Globals.UserRole = Globals.UserRoles.ADMIN;
            AppUser.UserRole = AppUser.UserRoles.EMPLOYEE;

            if (AppUser.UserRole == AppUser.UserRoles.CUSTOMER)
            {
                return RedirectToAction("TakeOutMenu", "Menu");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }

        public IActionResult LogUserOut()
        {
            Globals.UserSignedIn = false;

            // Globals.UserRole = Globals.UserRoles.Patron;//Globals.UserRoles.Admin;

            return RedirectToAction("SignIn", "MyAccount");


        }
    }

}
