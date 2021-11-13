using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

using Data.DbContext;
using Data.Models;
using Data.Models.DashboardData;
using Data.Models.FoodMenus;
using Data.Models.User;
using Data.Repositories;
using Data.ViewModels;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace RamenOkiDoki.Controllers
{
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DatabaseRepository _databaseRepository;

        private RestaurantDbContext _context;

        //  public List<FoodItem> FoodItemList;

        public AdminController(ILogger<HomeController> logger, DatabaseRepository databaseRepository)
        {
            _logger = logger;
            _databaseRepository = databaseRepository;
        }


        //returns the users to the index(home of the index view page)
        public IActionResult Index()
        {
            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            return View(dashboardViewModel);

        }

        //Gets the menu from cloud via SQL DB - and returns the view as Food Items which is created in FoodMenuViewModel
        public async Task<IActionResult> FoodMenuEdit()
        {
            Globals.FoodCategoryList = _databaseRepository.GetFoodCategories();
            Globals.FoodItemList = _databaseRepository.GetFoodItems();

            FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

            // FoodMenuViewModel.FoodItemList = new List<FoodItem>();


            if (Globals.FoodItemList != null)
            {
                foodMenuViewModel.FoodItemList = Globals.FoodItemList;

                if (Globals.FoodCategoryList != null)
                {
                    //foreach (var FoodItem in null)
                    //{

                    //}
                    foodMenuViewModel.FoodCategoryList = Globals.FoodCategoryList;

                }
            }

            if (foodMenuViewModel != null)
            {
                return View(foodMenuViewModel);
            }


            return View();
        }


        //Creates new item and returns to the menu.
        public IActionResult FoodMenuAddEdit(int? id)
        {
            FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

            if (id != null)
            {
                if (Globals.FoodItemList != null && Globals.FoodItemList.Count > 0)
                {
                    foreach (var item in Globals.FoodItemList)
                    {

                        if (item != null)
                        {
                            //   int.TryParse(item.id, out itemId);

                            if (item.Id == id)
                            {
                                foodMenuViewModel.FoodItemToAddEdit = item;
                                //return View(item);
                            }
                        }

                    }
                }
            }

            return View(foodMenuViewModel);

        }


        #region saving new item

        [HttpPost]
        public async Task<IActionResult> PutMenuItem(FoodItem item)
        {
            foreach (var category in Globals.FoodCategoryList)
            {
                if (category.Category == item.foodCategory)
                {
                    item.foodCategoryId = category.Id;
                }
            }

            //   await _menuEndpointService.AddMenuItemToCloud(item);

            return Redirect("FoodMenuEdit");
        }
        #endregion

        #region deleting  item
        public async Task<IActionResult> DeleteMenuItem(int? id)
        {
            if (id != null)
            {
                foreach (var item in Globals.FoodItemList)
                {
                    //  int.TryParse(item.Id, out itemId);

                    if (item.Id == id)
                    {
                        //We need to delete a Food Item from the database
                        _databaseRepository.DeleteItem(item);
                    }
                }
            }

            return RedirectToAction("FoodMenuEdit");
        }
        #endregion



        public IActionResult WebsiteInfoEdit()
        {
            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            return View(dashboardViewModel);

        }

        public IActionResult AdminSignin()
        {
            Globals.UserSignedIn = true;


           // Globals.UserRole = Globals.UserRoles.ADMIN;
            AppUser.UserRole = AppUser.UserRoles.EMPLOYEE;

            return Redirect("Index");
        }


        public IActionResult AdminSignOut()
        {
            Globals.UserSignedIn = false;

           // Globals.UserRole = Globals.UserRoles.Patron;//Globals.UserRoles.Admin;

            return Redirect("Index");

        }

        public IActionResult DashBoard()
        {
            return View("Index");
        }

        public IActionResult OpenAddressForm()
        {
            Globals.DisplayAddressForm = true;

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return RedirectToAction("Index", dashboardViewModel);
        }

        public IActionResult SaveBusinessLocation(DashboardViewModel dvm)
        {
            Globals.DisplayAddressForm = false;

            var location = dvm.MyBusinessLocation;

            if (location != null)
            {
                _databaseRepository.SaveRestaurantData<BusinessLocation>(location);
            }

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return RedirectToAction("Index", dashboardViewModel);
        }

        public IActionResult OpenHourOfOperationForm()
        {
            Globals.DisplayHoursForm = true;
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return RedirectToAction("Index", dashboardViewModel);
        }

        [HttpPost]
        public IActionResult SaveHoursOfOperation(DashboardViewModel dvm)
        {
            Globals.DisplayHoursForm = false;

            var hours = dvm.MyHoursOfOperation;

            if (hours != null)
            {
                _databaseRepository.SaveRestaurantData<HoursOfOperation>(hours);
            }

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return RedirectToAction("Index", dashboardViewModel);
        }

        public IActionResult OpenAddOnsForm()
        {
            Globals.DisplayAddOnsForm = true;

            return Redirect("Index");
        }

        public IActionResult SaveAddOnsForm(DashboardViewModel dvm)
        {
            Globals.DisplayAddOnsForm = false;

            AddOnCharges addOnCharges = dvm.AddOns;

            if (addOnCharges != null)
            {
                _databaseRepository.SaveRestaurantData<AddOnCharges>(addOnCharges);
            }

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return RedirectToAction("Index", dashboardViewModel);
        }
    }
}

