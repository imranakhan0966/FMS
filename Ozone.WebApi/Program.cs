using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.WebApi
{
    public class Program
    {
          public static IConfiguration config { get; private set; }
        public static void Main(string[] args)
        {
            //Read Configuration from appSettings
            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext()
                //.WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting up...");
                CreateHostBuilder(args).Build().Run();
                Log.Information("Shutting down...");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "API host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>()
                .UseConfiguration(config)
                .UseSerilog(); //Uses Serilog instead of default .NET Logger
            });
    }
}
