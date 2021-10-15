using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamenOkiDoki.Models
{
    public class OrderItem : FoodItem
    {
        public int quantity { get; set; }
    }
}
