using System.Text.Json.Serialization;

namespace Data.Models
{
    public class FoodItemOld
    {
        public string id { get; set; }
        public string dishName { get; set; }
        public string koreanName { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public FoodCategory foodCategory { get; set; }

        //public FoodItem()
        //{
                
        //}

        //public FoodItem(string id, string dishName, string koreanName, string description, string price, FoodCategory foodCategory)
        //{
        //    this.id = id;
        //    this.dishName = dishName;
        //    this.koreanName = koreanName;
        //    this.description = description;
        //    this.price = price;
        //    this.foodCategory = foodCategory;
        //}

        //public FoodItem(string id, string dishName, string koreanName, string description, string price)
        //{
        //    this.id = id;
        //    this.dishName = dishName;
        //    this.koreanName = koreanName;
        //    this.description = description;
        //    this.price = price;
        //}
    }
}
