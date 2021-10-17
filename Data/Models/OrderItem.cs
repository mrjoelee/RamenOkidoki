namespace Data.Models
{
    public class OrderItem : FoodMenu.FoodItem
    {
        public int quantity { get; set; }

        public OrderItem(string id, string dishName, string koreanName, string description, string price, FoodCategory categoryName, int quantity)// : base(id, dishName, koreanName, description, price, categoryName)
        {
            this.quantity = quantity;
        } 
        
    }
}
