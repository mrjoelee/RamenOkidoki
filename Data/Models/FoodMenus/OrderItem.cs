namespace Data.Models.FoodMenus
{
    public class OrderItem : FoodMenu.FoodItem
    {
        public int quantity { get; set; }

        //  public string categoryName { get; set; }

        public OrderItem(string id, string dishName, string description, string price, string foodCategory, string foodCategoryId, int quantity = 1)// : base(id, dishName, koreanName, description, price, categoryName)
        {
            this.id = id;
            this.dishName = dishName;
            this.description = description;
            this.price = price;
            this.foodCategory = foodCategory;
            this.foodCategoryId = foodCategoryId;
            this.quantity = quantity;
        }

    }
}
