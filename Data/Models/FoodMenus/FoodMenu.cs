using System.Collections.Generic;

namespace Data.Models.FoodMenus
{
    public class FoodMenu
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class FoodItem
        {
            public string id { get; set; }
            public string dishName { get; set; }
            public string koreanName { get; set; }
            public string description { get; set; }
            public string price { get; set; }
            public string foodCategoryId { get; set; }
            public string foodCategory { get; set; }
        }

        public class FoodCategory
        {
            public string id { get; set; }
            public string Category { get; set; }
            public List<FoodItem> FoodItems { get; set; }
        }

        //public class Root
        //{
        //    public List<FoodCategory> FoodCategories { get; set; }
        //}

    }
}