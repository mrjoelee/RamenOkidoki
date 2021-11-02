using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Data.Models;
using Data.Models.FoodMenus;

using Newtonsoft.Json;
namespace DataServices.Services
{
    public class MenuEndpointService
    {

        HttpClient httpClient = new HttpClient();

        public async Task<FoodMenu.FoodCategory> GetFoodMenuFromCloud()
        {
            try
            {
                var json = await httpClient.GetStringAsync((string?)Constants.MenuJsonUrl);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return null;
                }

                //  var root = JsonConvert.DeserializeObject<FoodMenu.Root>(json);

                var taskModels = JsonConvert.DeserializeObject<FoodMenu.FoodCategory>(json);


                return taskModels;
            }
            catch (Exception exception)
            {
                //  Crashes.TrackError(exception);
                return null;//default(T);
            }

        }

        public async Task<List<FoodMenu.FoodCategory>> GetFoodItemsFromCloud()
        {
            try
            {

                var json = await httpClient.GetStringAsync((string?)Constants.MenuGetUrl);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return null;
                }

                List<FoodMenu.FoodCategory> response = new List<FoodMenu.FoodCategory>();


                //    var result = JsonConvert.DeserializeObject<FoodMenu.FoodCategory>(json);

                 response = JsonConvert.DeserializeObject<List<FoodMenu.FoodCategory>>(json);

                 if (response == null)
                 {
                     return null;
                 }

                 foreach (var category in response)
                 {
                     foreach (var foodItem in category.FoodItems)
                     {
                         if (foodItem.foodCategoryId == category.Id)
                         {
                             foodItem.foodCategory = category.Category;
                         }
                     }
                 }



              //   = new List<FoodMenu.FoodCategory>(result.FoodCategories);

                //  response = JsonSerializer.Deserialize<List<FoodMenu.FoodCategory>>(json);

                return response;
            }
            catch (Exception exception)
            {
                //  Crashes.TrackError(exception);
                return null;//default(T);
            }

        }

        public async Task AddMenuItemToCloud(FoodMenu.FoodItem foodItemToAdd)
        {
            try
            {

                string url = Constants.MenuPostUrl; //Get url from the contants file 

                var json = JsonConvert.SerializeObject(foodItemToAdd); //Convert the FoodItem instance to json

                HttpContent content = new StringContent(json); // Add the json to the outgoing content

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); //Outgoing content will be of type Json

                HttpResponseMessage response = await httpClient.PutAsync(url, content); //Put the content to the specified url

            }
            catch (Exception ex)
            {
                //await Application.Current.MainPage.DisplayAlert("Unable To Connect", "We are unable to connect to the Farkle Website at this time. Please check your network connection.", "Okay");
            }
        }

        public async Task DeleteMenuItemFromCloud(int foodItemIdToDelete)
        {
            try
            {
                string url = Constants.MenuDeleteUrl; //Get url from the contants file 

                string idAsJson = "{ \"id\":" + foodItemIdToDelete + "}";

                HttpContent content = new StringContent(idAsJson); // Add the json to the outgoing content

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); //Outgoing content will be of type Json

                HttpResponseMessage response = await httpClient.PostAsync(url, content);




            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }

    }


    public class Root
    {
        public string id { get; set; }
        public string category { get; set; }
        public List<FoodMenu.FoodItem> FoodItems { get; set; }
    }
}
