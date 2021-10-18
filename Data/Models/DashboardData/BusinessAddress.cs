using System.ComponentModel.DataAnnotations;

namespace Data.Models.DashboardData
{
    public class BusinessAddress
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

    }
}
