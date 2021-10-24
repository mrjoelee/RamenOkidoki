using System.Collections.Generic;

using Data.Models.FoodMenus;

namespace Data.Models
{
    public class Globals
    {
        public static bool DisplayAddressForm { get; set; }
        public static bool DisplayHoursForm { get; set; }
        public static bool DisplayAddOnsForm { get; set; }
        public static bool UserSignedIn { get; set; }

        public static UserRoles UserRole { get; set; }

        public enum UserRoles { Admin, Employee, Patron }

        public static string CurrentCategory { get; set; }

        public static double OrderSubTotalCost { get; set; }
        public static double OrderTotalCost
        {
            get
            {
                return OrderSubTotalCost + TotalSalesTax;
            }
        }

        public static double TotalSalesTax
        {
            get
            {
                return OrderSubTotalCost * SalesTax;
            }
        }

        public static double SalesTax = 0.0625;

        public static string SalesTaxString
        {
            get
            {
                return $"{ SalesTax * 100}%";
            }
        }
            
        public static List<FoodMenu.FoodCategory> FoodCategoriesList { get; set; }

        public static List<FoodMenu.FoodItem> FoodItemsList { get; set; }

        public static FoodMenu.FoodCategory FoodCategory { get; set; }
        public static List<OrderItem> CartItemsList { get; set; }



        public Globals()
        {
            FoodCategoriesList = new List<FoodMenu.FoodCategory>();
            FoodItemsList = new List<FoodMenu.FoodItem>();
            FoodCategory = new FoodMenu.FoodCategory();
            CartItemsList = new List<OrderItem>();
        }

    }
}
