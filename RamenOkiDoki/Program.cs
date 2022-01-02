using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Models.Constants;

namespace RamenOkiDoki
{
    public class Program
    {
        //main function - starts as a main console application but calling the method IHostbuilder
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); 
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Keys.SyncfusionKey);
        }

        //create web application, uses the dependency injection
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
