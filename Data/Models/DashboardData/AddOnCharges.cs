using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.DashboardData
{
   public class AddOnCharges
   {
       [Key] public int Id { get; set; } = 1;

       [DisplayFormat(DataFormatString = "{0:0.0000}")]
       [Column(TypeName = "decimal(6,4)")]
        public decimal SalesTaxRate { get; set; } 

      


       [Column(TypeName = "decimal(5,2)")] 
       public decimal DeliveryCharge { get; set; }
   }
}
