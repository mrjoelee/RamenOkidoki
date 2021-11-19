using Data.Models.DashboardData;
using Data.Models.FoodMenus;
using Data.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;

namespace Data.Models.TakeOuts
{
    
    public class FoodOrder
    {
        private DatabaseRepository databaseRepository { get; set; }

        AddOnCharges addOns;

        [Key]
        public int Id { get; set; }

        public Customer RegisteredCustomer { get; set; }
        public string NonRegisteredCustomerLastName { get; set; }

        public int OrderTotalItems { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public  decimal OrderSubTotalCost { get; set; }

        public  decimal OrderTotalCost
        {
            get
            {
                return OrderSubTotalCost + TotalSalesTax;
            }
        }

        public  decimal TotalSalesTax
        {
            get
            {
                return OrderSubTotalCost * addOns.SalesTaxRate;
            }
        }

        public List<OrderItem>FoodOrderItemList { get; set; }

        public FoodOrder()
        {
            databaseRepository = new DatabaseRepository();

            addOns = databaseRepository.GetAddOnCharges();
            
      
            FoodOrderItemList = new List<OrderItem>();
            RegisteredCustomer = new Customer();
        }
    }
}
