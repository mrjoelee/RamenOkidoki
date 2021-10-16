using System.Text.Json.Serialization;

namespace Data.Models
{
    public class FoodCategory
    {
        public string CategoryName { get; set; }

        [JsonPropertyName("dishName")]
        public string DishName { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        //public override string ToString()
        //{
        //   return JsonSerializer.Serialize<FoodOld>(this);
        //}
    }
}
