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

        public static decimal OrderSubTotalCost { get; set; }
        public static decimal OrderTotalCost
        {
            get
            {
                return OrderSubTotalCost + TotalSalesTax;
            }
        }

        public static decimal TotalSalesTax
        {
            get
            {
                return OrderSubTotalCost * SalesTax;
            }
        }

        public static decimal SalesTax = 0.0625m;

        public static string SalesTaxString
        {
            get
            {
                return $"{ SalesTax * 100}%";
            }
        }
            
        public static List<FoodCategory> FoodCategoriesList { get; set; }

        public static List<FoodItem> FoodItemsList { get; set; }

        public static FoodCategory FoodCategory { get; set; }
        public static List<OrderItem> CartItemsList { get; set; }



        public Globals()
        {
            FoodCategoriesList = new List<FoodCategory>();
            FoodItemsList = new List<FoodItem>();
            FoodCategory = new FoodCategory();
            CartItemsList = new List<OrderItem>();
        }

    }
}
