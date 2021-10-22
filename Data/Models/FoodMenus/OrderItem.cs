namespace Data.Models.FoodMenus
{
    public class OrderItem : FoodMenu.FoodItem
    {
        public int quantity { get; set; }

        //  public string categoryName { get; set; }

        public OrderItem(string id, string dishName, string koreanName, string description, string price, string foodCategory, int quantity = 1)// : base(id, dishName, koreanName, description, price, categoryName)
        {
            this.id = id;
            this.dishName = dishName;
            this.koreanName = koreanName;
            this.description = description;
            this.price = price;
            this.foodCategory = foodCategory;
            this.quantity = quantity;
        }

    }
}
