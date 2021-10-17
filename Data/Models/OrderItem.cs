namespace Data.Models
{
    public class OrderItem : FoodMenu.FoodItem
    {
        public int quantity { get; set; }

        public string categoryName { get; set; }

        public OrderItem(string id, string dishName, string koreanName, string description, string price, string categoryName, int quantity = 1)// : base(id, dishName, koreanName, description, price, categoryName)
        {
            this.quantity = quantity;
        } 
        
    }
}
