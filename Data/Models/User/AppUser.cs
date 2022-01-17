using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.User
{

    public class AppUser : Microsoft.AspNet.Identity.EntityFramework.IdentityUser<int, IdentityUserLogin<int>, IdentityUserRole<int>, IdentityUserClaim<int>>
    {
        //add your custom properties which have not included in IdentityUser before

        public int UserId { get; set; }
        public string UserName { get; set; }    
        public string Password { get; set; }
        public static UserRoles UserRole { get; set; }

        public enum UserRoles { CUSTOMER, EMPLOYEE, MANAGER }
    }
}
