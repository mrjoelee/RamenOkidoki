using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.DashboardData
{
    public class BusinessLocation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public SocialPlatforms Social { get; set; }
        
        
    }

    public class SocialPlatforms
    {
        [Key]
        public int Id { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string YelpUrl { get; set; }
    }
}
