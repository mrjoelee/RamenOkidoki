using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Models.DashboardData;

namespace Data.ViewModels
{
    public class DashboardViewModel
    {
        public BusinessAddress BusinessLocation { get; set; }
        public HoursOfOperation HoursOfOperation { get; set; }

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
                SundayOpen = "10",
                SundayClose = "10",
                MondayOpen = "10",
                MondayClose = "10",
                TuesdayOpen = "10",
                TuesdayClose = "10",
                WednesdayOpen = "10",
                WednesdayClose = "10",
                ThursdayOpen = "10",
                ThursdayClose = "10",
                FridayOpen = "10",
                FridayClose = "10",
                SaturdayOpen = "10",
                SaturdayClose = "10"
            };
        }
    }

}
