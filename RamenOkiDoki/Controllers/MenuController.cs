using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data.Models;
using Data.Models.FoodMenus;
using Data.Repositories;
using Data.ViewModels;


using Microsoft.AspNetCore.Mvc;

namespace RamenOkiDoki.Controllers
{
    public class MenuController : Microsoft.AspNetCore.Mvc.Controller
    {
        private DatabaseRepository _databaseRepository;

        public MenuController(DatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<FoodItemsViewModel> MakeMenu()
        {
            Globals.FoodCategoryList = _databaseRepository.GetFoodCategories();

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            if (Globals.FoodCategoryList != null)
            {
                foodItemsViewModel.FoodCategoryList = Globals.FoodCategoryList;
            }

            return foodItemsViewModel;
        }

        #region =  Dine In Menu

        [Route("menu")]
        public async Task<IActionResult> DineInMenu()
        {
            var foodItemsViewModel = await MakeMenu();

            return View(foodItemsViewModel);
        }


        #endregion



        [Route("take-out")]
        public async Task<IActionResult> TakeOutMenu(string category)
        {
            List<FoodItem> tempListOfMenuItemsToReturn = new List<FoodItem>();

            // Get from MySql Database
            //   Globals.FoodCategoryList = await _menuEndpointService.GetFoodItemsFromCloud();

            var foodItemsViewModel = await MakeMenu();

            Globals.FoodCategoryList.OrderBy(Category => Category);

            if (Globals.FoodCategoryList == null)
            {
                return null;
            }

            // Get Categories that have food items


            List<string> tempListOfCategoryItems = new List<string>();

            foreach (var items in Globals.FoodCategoryList)
            {
                if (items.FoodItems != null && items.FoodItems.Count > 0)
                {
                    tempListOfCategoryItems.Add(items.Category);
                }
            }
            

            foodItemsViewModel.FoodCategoryList = tempListOfCategoryItems.Distinct().ToList();


            if (string.IsNullOrWhiteSpace(category))
            {
                if (string.IsNullOrWhiteSpace(Globals.CurrentCategory))
                {
                    category = tempListOfCategoryItems[0];
                }
                else
                {
                    category = Globals.CurrentCategory;
                }
            }


            foreach (var item in Globals.FoodCategoryList)
            {
                if (item.Category == (category))
                {
                    tempListOfMenuItemsToReturn = item.FoodItems;
                }
            }

            foodItemsViewModel.FoodItemList = tempListOfMenuItemsToReturn;

            return View(foodItemsViewModel);
        }


        //#region = Take Out Menu

        //[Route("take-out")]
        //public async Task<IActionResult> TakeOutMenu(string categoryString)
        //{
        //    var foodItemsViewModel = await MakeMenu();

        //           foreach (var cat in Globals.FoodCategoryList)
        //           {
        //               if (cat.FoodItems.Count >3)
        //               {
        //                   foodItemsViewModel.FoodItems = cat.FoodItems;
        //               }
        //           }


        //    foodItemsViewModel.FoodCategories = new List<string>();

        //    foreach (var category in foodItemsViewModel.FoodCategoryList)
        //    {
        //        if (category.FoodItems != null && category.FoodItems.Count > 0)
        //        {
        //              foodItemsViewModel.FoodCategories.Add(category.FoodItems[0].foodCategory);
        //        }

        //    }

        //    foodItemsViewModel.FoodCategories.Distinct().ToString();





        //    if (string.IsNullOrWhiteSpace(categoryString))
        //    {
        //        if (foodItemsViewModel.FoodCategories.Count > 0)
        //        {
        //            categoryString = foodItemsViewModel.FoodCategories[0];
        //        }

        //        if (Globals.CurrentCategory != null)
        //        {
        //            foreach (var category in foodItemsViewModel.FoodCategories)
        //            {
        //                if (category == Globals.CurrentCategory)
        //                {
        //                    categoryString = category;
        //                }
        //            }
        //        }

        //        Globals.CurrentCategory = categoryString;

        //    }

        //    foodItemsViewModel.FoodItems = new List<FoodMenu.FoodItem>();

        //    foreach (var categoryItem in foodItemsViewModel.FoodCategoryList)
        //    {
        //        if (true)//categoryItem.Category == (categoryString))
        //        {
        //            //if (categoryItem.FoodItems != null)
        //            //{
        //            foodItemsViewModel.FoodItems = categoryItem.FoodItems;
        //            //  }

        //        }
        //    }


        //    return View(foodItemsViewModel);
        //}

        //#endregion
    }
}

