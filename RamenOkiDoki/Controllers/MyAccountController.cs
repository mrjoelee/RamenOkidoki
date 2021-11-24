using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Models.User;

namespace RamenOkiDoki.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Register")]
        public IActionResult Register()
        {

            if (ModelState.IsValid)
            {

            }
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
            //look for signedin users in the database
            Globals.UserSignedIn = true;

            Globals.SignedInCustomer = new Customer();

            Globals.SignedInCustomer.Id = 2;
            Globals.SignedInCustomer.UserName = "Joe";


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
