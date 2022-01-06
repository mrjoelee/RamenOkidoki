using System;
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

        //private async Task<FoodMenuViewModel> MakeMenu()
        //{

        //    FoodMenuViewModel FoodMenuViewModel = new FoodMenuViewModel();

        //    if (Globals.FoodCategoryList != null)
        //    {
        //        FoodMenuViewModel.FoodCategoryList = Globals.FoodCategoryList;
        //    }

        //    return FoodMenuViewModel;
        //}

        #region =  Menu

        public IActionResult Menu()
        {
            FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();

            var validCategories = GetCategoriesToDisplay();

            if (validCategories == null) return null;

            foodMenuViewModel.FoodCategoryList = validCategories;

            return View(foodMenuViewModel);
        }


        #endregion



        private List<FoodCategory> GetCategoriesToDisplay()
        {
            if (Globals.FoodCategoryList == null)
            {
                return null;
            }

            List<FoodCategory> tempListOfMenuCategoriesToReturn = new List<FoodCategory>();

            //Loop through all categories

            foreach (var category in Globals.FoodCategoryList)
            {
                foreach (var item in Globals.FoodItemList)
                {
                    if (item.foodCategoryId == category.Id)
                    {
                        tempListOfMenuCategoriesToReturn.Add(category);
                    }
                }
            }

            //   var tempList = tempListOfMenuCategoriesToReturn.OrderBy(Category => Category).Distinct().ToList(); 

            var tempList = tempListOfMenuCategoriesToReturn.Distinct().ToList();

            return tempList;
        }


        //#region = Take Out Menu

        //[Route("take-out")]
        //public async Task<IActionResult> TakeOutMenu(string categoryString)
        //{
        //    var FoodMenuViewModel = await MakeMenu();

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
        //        if (FoodMenuViewModel.FoodCategories.Count > 0)
        //        {
        //            categoryString = FoodMenuViewModel.FoodCategories[0];
        //        }

        //        if (Globals.CurrentCategory != null)
        //        {
        //            foreach (var category in FoodMenuViewModel.FoodCategories)
        //            {
        //                if (category == Globals.CurrentCategory)
        //                {
        //                    categoryString = category;
        //                }
        //            }
        //        }

        //        Globals.CurrentCategory = categoryString;

        //    }

        //    FoodMenuViewModel.FoodItems = new List<FoodMenu.FoodItem>();

        //    foreach (var categoryItem in FoodMenuViewModel.FoodCategoryList)
        //    {
        //        if (true)//categoryItem.Category == (categoryString))
        //        {
        //            //if (categoryItem.FoodItems != null)
        //            //{
        //            FoodMenuViewModel.FoodItems = categoryItem.FoodItems;
        //            //  }

        //        }
        //    }


        //    return View(FoodMenuViewModel);
        //}

        //#endregion
    }
}

