using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using RamenOkiDoki.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RamenOkiDoki.Services
{
    public class JSonFileFoodService
    {
        public JSonFileFoodService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "FoodMenu.json");}
        }

        public Food.Root GetFoodMenuFromFile()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Food.Root>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
