using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.DbContext;
using Data.Models;
using Data.Models.DashboardData;

using Microsoft.EntityFrameworkCore;

namespace Data.ViewModels
{
    public class DashboardViewModel
    {
        public DbSet<BusinessLocation> BusinessLocation { get; set; }
        public DbSet<HoursOfOperation> HoursOfOperation { get; set; }

        public DbSet<AddOnCharges> AddOns { get; set; }

        //public BusinessLocation MyBusinessLocation { get; set; }
        //public HoursOfOperation MyHoursOfOperation { get; set; }

        //   public AddOnCharges AddOns { get; set; }

        public List<Review> Reviews { get; set; }

        public int NewRating { get; set; }

        //public DashboardViewModel(RestaurantDbContext context)
        //{
        //    var context1 = context;

        //    // BusinessLocation = DummyData.GetBusinessLocation();

        //    BusinessLocation = context1.BusinessLocations;

        //    //HoursOfOperation = DummyData.GetHoursOfOperation();

        //    HoursOfOperation = context1.BusinessHours;

        //    AddOns = context1.AddOns;

        //}
    }

}
