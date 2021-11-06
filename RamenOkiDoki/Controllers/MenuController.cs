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

        //private async Task<FoodItemsViewModel> MakeMenu()
        //{

        //    FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

        //    if (Globals.FoodCategoryList != null)
        //    {
        //        foodItemsViewModel.FoodCategoryList = Globals.FoodCategoryList;
        //    }

        //    return foodItemsViewModel;
        //}

        #region =  Dine In Menu

        [Route("menu")]
        public async Task<IActionResult> DineInMenu()
        {
            FoodMenuViewModel foodItemsViewModel = new FoodMenuViewModel();

            return View(foodItemsViewModel);
        }


        #endregion



        [Route("take-out")]
        public async Task<IActionResult> TakeOutMenu(string categoryName)
        {
            FoodMenuViewModel foodMenuViewModel = new FoodMenuViewModel();
            List<FoodCategory> tempListOfMenuCategoriesToReturn = new List<FoodCategory>();
            List<FoodItem> tempListOfMenuItemsToReturn = new List<FoodItem>();


            //     Globals.FoodCategoryList.OrderBy(Category => Category);

            if (Globals.FoodCategoryList == null)
            {
                return null;
            }

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

            foodMenuViewModel.FoodCategoryList = tempListOfMenuCategoriesToReturn.OrderBy(Category => Category).Distinct().ToList();

            // Show Categories that have food items

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                if (Globals.CurrentCategory == null)
                {
                    Globals.CurrentCategory = foodMenuViewModel.FoodCategoryList[0];
                }
                else
                {
                    categoryName = Globals.CurrentCategory.Category;
                }
            }


            if (Globals.FoodItemList != null & Globals.FoodItemList.Count > 0)
            {
                foreach (var item in Globals.FoodItemList)
                {
                    if (item != null)
                    {
                        tempListOfMenuItemsToReturn.Add(item);
                    }
                }
            }


            foodMenuViewModel.FoodItemList = tempListOfMenuItemsToReturn;

            return View(foodMenuViewModel);
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

