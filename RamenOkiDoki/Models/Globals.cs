using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamenOkiDoki.Models
{
    public class Globals
    {
        public static bool UserSignedIn { get; set; }

        public static UserRoles UserRole { get; set; }

        public enum UserRoles { Admin, Employee , Patron}

        public static List<FoodItem> FoodItems;

        public static List<OrderItem> CartItems;

        public static List<FoodItem> Items;

        public static string CurrentCategory;
    }
}
