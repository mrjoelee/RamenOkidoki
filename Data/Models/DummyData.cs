using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Models.DashboardData;

namespace Data.Models
{
    public class DummyData
    {
        public static BusinessAddress GetBusinessLocation()
        {
            return new BusinessAddress()
            {
                BusinessName = "Ramen OkiDoki",
                StreetAddress = "10603 Bellaire Blvd",
                City = "Houston",
                State = "TX",
                Zipcode = "77072",
                PhoneNumber = "2815758077",
                Email = ""
            };
        }


        public static HoursOfOperation GetHoursOfOperation()
        {
            return new HoursOfOperation()
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
        }


        public static List<Review> GetReviews()
        {
            return new List<Review>()
            {
                new Review("Mario P.",
                    "Food was too good to take pictures of. That’s all I have to say. Apologies, I know people like pics of the food. But it was that good. Ramen was on point! Go here. You will be more than pleased.",
                    5, "June 2021"),

                new Review("Madai G.",
                    "I honestly don’t understand where these bad reviews are coming from!!! The good is unforgettable! Tonkatsu ramen, garlic soy wings and kimchi fries are definite no brainers. Excellent customer service. Have been here twice before reviewing. This place deserves the credit it deserves. Almost didn’t come because of the negative reviews. Glad my husband convinced me to give it a shot!!! Our new family outing fav.",
                    5, "June 2021"),

                new Review("Meisha E.",
                    "The food and service was good excellent!!!! We got the onagiri is really, very flavorful and the pickled radish added a lot of twang. We also got a bin which was good too. We got the spicy tonkatsu ramen.... Best I've had in Houston. I don't even like ramen like that but this broth was very creamy, and flavorful",
                    5, "June 2021"),

                new Review("Paul L.",
                    "Great ramens and authentic awesome KFC (Korean Fried Chicken). Appetizers are great too. Friendly staff. To-go orders are well prepared. I highly recommend.",
                    5, "June 2021"),

                new Review("Erica P.",
                    "The ramen and garlic soy wings were delish. The customer service was also great!", 5, "September 2021"),

                new Review("Nhan V.",
                    "I LOVE THIS PLACE!! I go here at least once a week ahaha! The owner is super nice and it's quite impressive how he manage this whole place by himself sometimes.",
                    5, "August 2021"),

                new Review("AD Avenue Group",
                    "Good taste. Staff is friendly clean place. I took the tonkotsu ramen with an extra egg. Delicious.",
                    5, "June 2021"),

                new Review("Lv126 M.", "Great ramen for a good price. I recommend coming here.", 5, "August 2021"),

                new Review("Sharon Ree",
                    "Very true to the Japanese and Korean pub style interior. One thing… throughout the meal, the metal chairs were very loud, screeching against the floor, every time someone got up or sat back down…We had spicy chicken wings, takoyaki, and spicy miso and the house okidoki ramen… they were all well cooked, perfectly seasoned, and Bathroom is odd. Hallway and bathroom itself were Houston hot. Meaning it’s not air conditioned. Maybe an exterior addition… spicy miso wasn’t that spicy. It was more medium korean spicy :) but I got more spice on the side.The service was good, nothing special, , parking aplenty outside, the bathrooms were odd and the hallway and the bathroom itself aren’t air conditioned so you are met with a wall of hot, humid air. It seems like a last minute add on.. but having access to bathrooms during covid is good.. we will def return and try other things, because the food is solid and my kids loved it.",
                    4, "September 2021"),

                new Review("Serena S.",
                    "Nice little gem in China town! We came here yesterday at about 6 pm; we were the only ones in the restaurant! Really enjoyed the fries; probably as good and comparable to McDonald's but the toppings were extra tasty. Both of our portions were amazing for the ramen!! I had so much to take home which I feel is a little rare for ramen places. I think the visuals were really nice. I took off one star because while the ramen was okay I think my boyfriends broth was just a tad on the watery side. Overall will be coming back the next time I'm craving some ramen!",
                    4, "September 2021"),

                new Review("Lan N.",
                    "This is definitely my go-to ramen place. On Thursdays from 5PM until close, they have a $6.99 special on ANY ramen. This is definitely a steal! The ramen itself tastes good - broth is flavorful and noodles have a good texture. Only downside is that the wait is a little long for your ramen to come out, but other than that, I definitely recommend!",
                    4, "August 2021"),

                new Review("Stephanie D.",
                    "Good ramen. Been coming here for about 2 years. I have notice that before the pork meat use to be thick now it is very thin. But it is still very good flavor.",
                    4, "September 2021"),

                new Review("Peter S.",
                    "Service was fine on a Thursday evening . Not too pack. Food was ok at best Pork bun wasn't good at all. Bun was flat and pork was overcook and sitting Ramen was 'ok' didn't finish it. Everything tasted dated Wings was good best thing we had . It was really good .",
                    4, "June 2021")
            };
        }
    }
}
