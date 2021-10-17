﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class FoodMenu
    {
        public class FoodItem
        {
            public string id { get; set; }
            public string dishName { get; set; }
            public string koreanName { get; set; }
            public string description { get; set; }
            public string price { get; set; }
            public string foodCategory { get; set; }

            //public string id { get; set; }
            //public string dishName { get; set; }
            //public string koreanName { get; set; }
            //public string description { get; set; }
            //public string price { get; set; }
            //public string foodCategoryId { get; set; }
        }

        public class Root
        {
            public string id { get; set; }

            [JsonPropertyName("category")]
            public string Category { get; set; }


            [JsonPropertyName("FoodItems")]
            public List<FoodItem> FoodItems { get; set; }
        }

    }
}