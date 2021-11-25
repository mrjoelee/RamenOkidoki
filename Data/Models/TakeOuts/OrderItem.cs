using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.TakeOuts
{
    public class OrderItem /*: FoodItem*/
    {
        [Key]
        public int OrderItemId { get; set; }

        [ForeignKey("FoodOrder")]
        public int OrderId { get; set; }
        public int quantity { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal price { get; set; }
        public string dishName { get; set; }
        
 



        //  public string categoryName { get; set; }

        public OrderItem(int orderItemId, string dishName, decimal price, int quantity = 1)// : base(id, dishName, koreanName, description, price, categoryName)
        {
            this.OrderItemId = orderItemId;
            this.dishName = dishName;
            this.price = price;
            this.quantity = quantity;
        }

    }
}
