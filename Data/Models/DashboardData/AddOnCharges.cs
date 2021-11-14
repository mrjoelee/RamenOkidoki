using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.DashboardData
{
   public class AddOnCharges
   {
       [Key] public int Id { get; set; } = 1;

       [DisplayFormat(DataFormatString = "{0:0.00000}")]
        public decimal SalesTaxRate { get; set; } 
        //public string SalesTax { get; set; }
        public decimal DeliveryCharge { get; set; }
   }
}
