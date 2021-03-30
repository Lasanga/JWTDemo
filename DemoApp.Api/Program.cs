using DemoApp.Core;
using DemoApp.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DemoApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var config = host.Services.GetRequiredService<IConfiguration>();
            if (Convert.ToBoolean(config.GetSection("IsSeed").Value))
            {
                var connectionString = config.GetConnectionString(Constants.DbConnectionStringKey);
                SeedData.EnsureSeedData(connectionString);
            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
