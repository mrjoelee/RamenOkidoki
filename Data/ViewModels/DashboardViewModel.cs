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

      //  public BusinessLocation BusinessLocation { get; set; }
      //  public HoursOfOperation HoursOfOperation { get; set; }

        //   public AddOnCharges AddOns { get; set; }

        public List<Review> Reviews { get; set; }

        public int NewRating { get; set; }

        private readonly RestaurantDbContext _context;
        public DashboardViewModel(RestaurantDbContext context)
        {
            _context = context;

            // BusinessLocation = DummyData.GetBusinessLocation();

            BusinessLocation = _context.BusinessLocations;

            //HoursOfOperation = DummyData.GetHoursOfOperation();

            HoursOfOperation = _context.BusinessHours;

            AddOns = _context.AddOns;

        }
    }

}
