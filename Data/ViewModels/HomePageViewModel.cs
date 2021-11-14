using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Models;
using Data.Models.DashboardData;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.ViewModels
{
    public class HomePageViewModel
    {
        private DatabaseRepository databaseRepository { get; set; }
        public BusinessLocation MyBusinessLocation { get; set; }
        public HoursOfOperation MyHoursOfOperation { get; set; }
        public List<CustomerReview> Reviews { get; set; }
        public CustomerReview NewReview { get; set; }
        public bool ShowAllReviews { get; set; }

        // public int NewRating { get; set; }

        public HomePageViewModel()
        {
            databaseRepository = new DatabaseRepository();

            MyBusinessLocation = databaseRepository.GetBusinessLocation();

            MyHoursOfOperation = databaseRepository.GetHoursOfOperation();

            //BusinessLocation = new BusinessLocation()
            //{
            //    BusinessName = "Ramen OkiDoki",
            //    StreetAddress = "10603 Bellaire Blvd",
            //    City = "Houston",
            //    State = "TX",
            //    Zipcode = "77072",
            //    PhoneNumber = "2815758077",
            //    Email = ""
            //};

           // HoursOfOperation = DummyData.GetHoursOfOperation();

            Reviews = DummyData.GetReviews();

            NewReview = new CustomerReview();
        }
    }

}
