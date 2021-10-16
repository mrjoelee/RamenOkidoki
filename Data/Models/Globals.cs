using System.Collections.Generic;

namespace Data.Models
{
    public class Globals
    {
        public static bool UserSignedIn { get; set; }

        public static UserRoles UserRole { get; set; }

        public enum UserRoles { Admin, Employee , Patron}

        public static List<FoodItem> FoodItems{ get; set; }

        public static List<OrderItem> CartItems { get; set; }

        public static List<FoodItem> Items { get; set; }

        public static string CurrentCategory { get; set; }

        public static double OrderTotalCost { get; set; }
    }
}
