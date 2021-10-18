using System.ComponentModel.DataAnnotations;

namespace Data.Models.DashboardData
{
    public class BusinessAddress
    {

        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

    }
}
