using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.FoodMenus
{
    public class FoodMenu
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class FoodItem
        {
            [Key]
            public int Id { get; set; }
            public string dishName { get; set; }
            public string description { get; set; }
            public string price { get; set; }

            [ForeignKey("Id")]
            public int foodCategoryId { get; set; }
            public string foodCategory { get; set; }
        }

        public class FoodCategory
        {
            [Key] public int Id { get; set; }
            public string Category { get; set; }
            public List<FoodItem> FoodItems { get; set; }
        }

        //public class Root
        //{
        //    public List<FoodCategory> FoodCategories { get; set; }
        //}

    }
}