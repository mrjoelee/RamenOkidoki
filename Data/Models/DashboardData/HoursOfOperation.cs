using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.DashboardData
{


    public class HoursOfOperation
    {
        [Key] public int Id { get; set; } = 1;
        public string SundayOpen { get; set; }
        public string SundayClose { get; set; }
        public string MondayOpen { get; set; }
        public string MondayClose { get; set; }
        public string TuesdayOpen { get; set; }
        public string TuesdayClose { get; set; }
        public string WednesdayOpen { get; set; }
        public string WednesdayClose { get; set; }
        public string ThursdayOpen { get; set; }
        public string ThursdayClose { get; set; }
        public string FridayOpen { get; set; }
        public string FridayClose { get; set; }
        public string SaturdayOpen { get; set; }
        public string SaturdayClose { get; set; }
    }
}
