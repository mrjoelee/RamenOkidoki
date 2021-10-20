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
        }
    }

}
