using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data.Models;
using Task = System.Threading.Tasks.Task;

namespace RamenOkiDoki.Services
{
    public class MenuEndpointService
    {

        HttpClient httpClient = new HttpClient();

        public async Task<Food.Root> GetFoodMenuFromCloud()
        {
            try
            {
                var json = await httpClient.GetStringAsync(Constants.MenuJsonUrl);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return null;
                }

                var taskModels = JsonSerializer.Deserialize<Food.Root>(json);


                return taskModels;
            }
            catch (Exception exception)
            {
                //  Crashes.TrackError(exception);
                return null;//default(T);
            }

        }

        public async Task<List<FoodItem>> GetFoodItemsFromCloud()
        {
            try
            {

                var json = await httpClient.GetStringAsync(Constants.MenuGetUrl);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return null;
                }

                var taskModels = JsonSerializer.Deserialize<List<FoodItem>>(json);

                return taskModels;
            }
            catch (Exception exception)
            {
                //  Crashes.TrackError(exception);
                return null;//default(T);
            }

        }

        public async Task AddMenuItemToCloud(FoodItem foodItemToAdd)
        {
            try
            {

                string url = Constants.MenuPostUrl; //Get url from the contants file 

                var json = JsonSerializer.Serialize(foodItemToAdd); //Convert the FoodItem instance to json

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
}
