using Data.Models.DashboardData;
using Data.Models.FoodMenus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.TakeOuts
{
    
    public class FoodOrder
    {
        AddOnCharges addOns;

        [Key]
        public int Id { get; set; }

        public Customer TakeOutCustomer { get; set; }

        public  double OrderSubTotalCost { get; set; }

        public  double OrderTotalCost
        {
            get
            {
                return OrderSubTotalCost + TotalSalesTax;
            }
        }

        public  double TotalSalesTax
        {
            get
            {
                return OrderSubTotalCost * addOns.SalesTaxRate;
            }
        }

        public List<OrderItem>FoodOrderItems { get; set; }

        public FoodOrder()
        {
            addOns = new AddOnCharges();
            FoodOrderItems = new List<OrderItem>();
            TakeOutCustomer = new Customer();
        }
    }
}
