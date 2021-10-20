using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.DashboardData
{
    public class BusinessAddress
    {

        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public SocialPlatforms Social { get; set; }


        private string phoneFormattedNumber;

        public string PhoneFormattedNumber
        {
            get
            {
                return $"{PhoneNumber:(000) 000-0000}";

                //  set { phoneFormattedNumber = value; }

            }
        }
        
    }

    public class SocialPlatforms
    {
    }
}
