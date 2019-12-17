using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoadStatus.ApiHelper;
using RoadStatus.Interfaces;
using RoadStatus.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RoadStatus
{
    class Program
    {
        private static IServiceProvider ServiceProvider;
        static async Task Main(string[] args)
        {

            // Register services

            RegisterServices();

            var configBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var apiSettings = configBuilder.GetSection("TFLApiSettings")
                .Get<ApiSettings>();

            var roadstatusService = ServiceProvider.GetService<IRoadStatusService>();

            var roadName = "";

            var result = "";

            var exitCode = 0;

            if (args.Length > 0)
            {
                roadName = args[0];
            }

            try
            {
                result = await roadstatusService.GetRoadStatusAsync(apiSettings, roadName);

            }
            catch (Exception ex)
            {
                result = ex.Message;
                exitCode = 1;
            }
            finally
            {
                Console.WriteLine(result);
                Environment.ExitCode = exitCode;
            }


            // Dispose services
            DisposeServices();
        }

        private static void RegisterServices()
        {
            //DI

            ServiceProvider = new ServiceCollection()
                .AddSingleton<IAsyncApiContext, AsyncApiContext>()
                .AddScoped<IRoadStatusService, RoadStatusService>()
                .BuildServiceProvider();
        }
        private static void DisposeServices()
        {


            if (ServiceProvider == null)
            {
                return;
            }
            if (ServiceProvider is IDisposable)
            {
                ((IDisposable)ServiceProvider).Dispose();
            }
        }
    }
}
