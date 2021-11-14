using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CustomerReview
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewString { get; set; }

        public string ReviewDate { get; set; }
        public int Rating { get; set; }

        public CustomerReview()
        {
                
        }

        public CustomerReview(string reviewerName, string reviewString, int rating, string reviewDate)
        {
            ReviewerName = reviewerName;
            ReviewString = reviewString;
            Rating = rating;
            ReviewDate = reviewDate;
        }
    }
}
