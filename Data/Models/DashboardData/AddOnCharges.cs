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

        public  double SalesTaxRate = 0.0625;
        //public string SalesTax { get; set; }
        public double DeliveryCharge { get; set; }
    }
}
