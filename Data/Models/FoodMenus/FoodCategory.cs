using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.FoodMenus
{
    public class FoodCategory
    {

        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        // public List<FoodItem> FoodItems { get; set; }
    }
}
