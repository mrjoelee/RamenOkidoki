using System.Collections.Generic;

namespace Data.Models
{
    public class Food
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Appetizer
        {
            public string dishName { get; set; }
            public string price { get; set; }
            public string description { get; set; }
        }

        public class Soup
        {
            public string dishName { get; set; }
            public string price { get; set; }
            public string description { get; set; }
        }

        public class Bibimbap
        {
            public string dishName { get; set; }
            public string price { get; set; }
            public string description { get; set; }
        }

        public class FriedRice
        {
            public string dishName { get; set; }
            public string price { get; set; }
            public string description { get; set; }
        }

        public class Specials
        {
            public string dishName { get; set; }
            public string price { get; set; }
            public string description { get; set; }
        }

        public class StirFried
        {
            public string dishName { get; set; }
            public string price { get; set; }
            public string description { get; set; }
        }

        public class Noodle
        {
            public string dishName { get; set; }
            public string price { get; set; }
            public string description { get; set; }
        }

        public class Combination
        {
            public string dishName { get; set; }
            public string price { get; set; }
            public string description { get; set; }
        }

        public class Chinese
        {
            public string dishName { get; set; }
            public string price { get; set; }
            public string description { get; set; }
        }

        public class FoodCategory
        {
            public List<Appetizer> Appetizers { get; set; }
            public List<Soup> Soup { get; set; }
            public List<Bibimbap> Bibimbap { get; set; }

            public List<FriedRice> FriedRice { get; set; }
            public List<Specials> Specials { get; set; }

            public List<StirFried> StirFried { get; set; }
            public List<Noodle> Noodles { get; set; }
            public List<Combination> Combination { get; set; }
            public List<Chinese> Chinese { get; set; }
        }

        public class Root
        {
            public FoodCategory FoodCategory { get; set; }
        }

    }
}
