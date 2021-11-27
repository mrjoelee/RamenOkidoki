using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.TakeOuts
{
    public class OrderItem 
    {
        [Key]
        public int OrderItemId { get; set; }

        //[ForeignKey("FoodOrder")]
        //public int OrderId { get; set; }
        public int quantity { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal price { get; set; }
        public string dishName { get; set; }
        
 
        public OrderItem(int orderItemId, string dishName, decimal price, int quantity = 1)
        {
            this.OrderItemId = orderItemId;
            this.dishName = dishName;
            this.price = price;
            this.quantity = quantity;
        }

    }
}
