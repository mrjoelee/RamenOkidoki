using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.User
{
    public class RegisteredTakeoutUser : TakeOutUser, IAppUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
