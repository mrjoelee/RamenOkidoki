using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Models;
using Data.Models.DashboardData;

namespace Data.ViewModels
{
    public class DashboardViewModel
    {
        public BusinessAddress BusinessLocation { get; set; }
        public HoursOfOperation HoursOfOperation { get; set; }
        public string SalesTax { get; set; }

        public List<Review> Reviews { get; set; }

        public DashboardViewModel()
        {
            BusinessLocation = new BusinessAddress()
            {
                BusinessName = "Ramen OkiDoki",
                StreetAddress = "10603 Bellaire Blvd",
                City = "Houston",
                State = "TX",
                Zipcode = "77072",
                PhoneNumber = "2815758077",
                Email = ""
            };

            HoursOfOperation = new HoursOfOperation()
            {
                SundayOpen = "11am",
                SundayClose = "9:30pm",
                MondayOpen = "11am",
                MondayClose = "9:30pm",
                TuesdayOpen = "11am",
                TuesdayClose = "9:30pm",
                WednesdayOpen = "11am",
                WednesdayClose = "9:30pm",
                ThursdayOpen = "11am",
                ThursdayClose = "9:30pm",
                FridayOpen = "11am",
                FridayClose = "9:30pm",
                SaturdayOpen = "11am",
                SaturdayClose = "9:30pm"
            };

            SalesTax = Globals.SalesTax.ToString();


            Reviews = new List<Review>()
            {
                new Review("Sharon Ree", "Very true to the Japanese and Korean pub style interior. One thing… throughout the meal, the metal chairs were very loud, screeching against the floor, every time someone got up or sat back down…We had spicy chicken wings, takoyaki, and spicy miso and the house okidoki ramen… they were all well cooked, perfectly seasoned, and Bathroom is odd. Hallway and bathroom itself were Houston hot. Meaning it’s not air conditioned. Maybe an exterior addition… spicy miso wasn’t that spicy. It was more medium korean spicy :) but I got more spice on the side.The service was good, nothing special, , parking aplenty outside, the bathrooms were odd and the hallway and the bathroom itself aren’t air conditioned so you are met with a wall of hot, humid air. It seems like a last minute add on.. but having access to bathrooms during covid is good.. we will def return and try other things, because the food is solid and my kids loved it.", 4 ),

                new Review("Serena S.", "Nice little gem in China town! We came here yesterday at about 6 pm; we were the only ones in the restaurant! Really enjoyed the fries; probably as good and comparable to McDonald's but the toppings were extra tasty. Both of our portions were amazing for the ramen!! I had so much to take home which I feel is a little rare for ramen places. I think the visuals were really nice. I took off one star because while the ramen was okay I think my boyfriends broth was just a tad on the watery side. Overall will be coming back the next time I'm craving some ramen!", 4 ),

                new Review( "Lan N.", "This is definitely my go-to ramen place. On Thursdays from 5PM until close, they have a $6.99 special on ANY ramen. This is definitely a steal! The ramen itself tastes good - broth is flavorful and noodles have a good texture. Only downside is that the wait is a little long for your ramen to come out, but other than that, I definitely recommend!", 4)
            };
        }
    }

}
