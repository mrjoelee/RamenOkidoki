using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class FoodCategory
    {
        public string id { get; set; }
        public string CategoryName { get; set; }

        public List<FoodMenu.FoodItem> FoodItems { get; set; }

        public FoodCategory(string categoryName)
        {
            CategoryName = categoryName;
        }

        //[JsonPropertyName("dishName")]
        //public string DishName { get; set; }
        
        //[JsonPropertyName("description")]
        //public string Description { get; set; }

        //[JsonPropertyName("price")]
        //public int Price { get; set; }

        //public override string ToString()
        //{
        //   return JsonSerializer.Serialize<FoodOld>(this);
        //}
    }
}
