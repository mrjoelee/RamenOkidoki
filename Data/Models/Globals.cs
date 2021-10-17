using System.Collections.Generic;

namespace Data.Models
{
    public class Globals
    {
        public static bool UserSignedIn { get; set; }

        public static UserRoles UserRole { get; set; }

        public enum UserRoles { Admin, Employee, Patron }



        public static List<OrderItem> CartItemsList { get; set; }


        public static List<FoodMenu.FoodCategory> FoodCategoriesList { get; set; }


        public static List<FoodMenu.FoodItem> FoodItemsList { get; set; }

        public static FoodMenu.FoodCategory FoodCategory { get; set; }

        public static string CurrentCategory { get; set; }


        public static double OrderTotalCost { get; set; }
    }
}
