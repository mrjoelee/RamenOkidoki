using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Models;
using Data.Models.DashboardData;

namespace Data.ViewModels
{
    public class HomePageViewModel
    {
        public BusinessAddress BusinessLocation { get; set; }
        public HoursOfOperation HoursOfOperation { get; set; }
        public List<Review> Reviews { get; set; }
        public Review NewReview { get; set; }
        public bool ShowAllReviews { get; set; }

        // public int NewRating { get; set; }

        public HomePageViewModel()
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

            HoursOfOperation = DummyData.GetHoursOfOperation();

            Reviews = DummyData.GetReviews();

            NewReview = new Review();
        }
    }

}
