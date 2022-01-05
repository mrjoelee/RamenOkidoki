using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.FoodMenus
{
    public class FoodItem
    {
        [Key]
        public int Id { get; set; }
        public string dishName { get; set; }
        public string description { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal price { get; set; }

        //[ForeignKey("Id")]
        public int foodCategoryId { get; set; }
        public string foodCategory { get; set; }
    }
}
