using System;
using System.Collections.Generic;
using System.Web;

using Data.Models;
using Data.Models.Constants;
using Data.Models.DashboardData;
using Data.Models.FoodMenus;
using Data.Models.TakeOuts;
using Data.Models.User;

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Data.DbContext
{
    public class AppUserContext : IdentityDbContext<AppUser>
    {
        public AppUserContext()
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<TakeOutUser> TakeOutUsers { get; set; }

    }
}