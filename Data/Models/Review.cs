using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Review
    {
        public string ReviewerName { get; set; }
        public string ReviewString { get; set; }
        public int Rating { get; set; }

        public Review()
        {
                
        }

        public Review(string reviewerName, string reviewString, int rating)
        {
            ReviewerName = reviewerName;
            ReviewString = reviewString;
            Rating = rating;
        }
    }
}
