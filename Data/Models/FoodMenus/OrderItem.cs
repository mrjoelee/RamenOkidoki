using System.ComponentModel.DataAnnotations;

namespace Data.Models.FoodMenus
{
    public class OrderItem : FoodMenu.FoodItem
    {
        [Key]
        public int Id { get; set; }
        public int quantity { get; set; }

        //  public string categoryName { get; set; }

        public OrderItem(int id, string dishName, string description, string price, string foodCategory, int foodCategoryId, int quantity = 1)// : base(id, dishName, koreanName, description, price, categoryName)
        {
            Id = id;
            this.dishName = dishName;
            this.description = description;
            this.price = price;
            this.foodCategory = foodCategory;
            this.foodCategoryId = foodCategoryId;
            this.quantity = quantity;
        }

    }
}
