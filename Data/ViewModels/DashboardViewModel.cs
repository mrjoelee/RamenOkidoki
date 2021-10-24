using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Models.DashboardData;

namespace Data.ViewModels
{
    public class DashboardViewModel
    {
        public BusinessAddress BusinessLocation { get; set; }
        public HoursOfOperation HoursOfOperation { get; set; }
        public string SalesTax { get; set; }

        public DashboardViewModel()
        {
            BusinessLocation = new BusinessAddress()
            {
                BusinessName = "Ramen OkiDoki",
                StreetAddress = "10603 Bellaire Blvd",
                City = "Houston",
                State = "TX",
                Zipcode = "77072",
                PhoneNumber = "2815758077",
                Email = ""
            };

            HoursOfOperation = new HoursOfOperation()
            {
                SundayOpen = "11am",
                SundayClose = "9:30pm",
                MondayOpen = "11am",
                MondayClose = "9:30pm",
                TuesdayOpen = "11am",
                TuesdayClose = "9:30pm",
                WednesdayOpen = "11am",
                WednesdayClose = "9:30pm",
                ThursdayOpen = "11am",
                ThursdayClose = "9:30pm",
                FridayOpen = "11am",
                FridayClose = "9:30pm",
                SaturdayOpen = "11am",
                SaturdayClose = "9:30pm"
            };

            SalesTax = Globals.SalesTax.ToString();
        }
    }

}
