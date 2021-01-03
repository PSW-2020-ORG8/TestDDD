using System;
using System.Threading.Tasks;
using IntegrationAdapters.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntegrationAdapters
{
    public class Program
    {
        static async Task Main(string[] args)
        {
          /*  Console.WriteLine("Enter medication:");
 
            string input = Console.ReadLine();

            await HttpInquiriesController.SendRequest(input);*/
           
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ClientScheduledService>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
