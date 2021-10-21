using ConfigurationComparator.ConfigurataionService;
using ConfigurationComparator.Logging;
using ConfigurationComparator.Cache;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            ConfigurationManager(host.Services);

            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<IConfFileCache, ConfFileCache>()
                    .AddMemoryCache());
        }

        public static void ConfigurationManager(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;
            var confCache = provider.GetRequiredService<IConfFileCache>();

            var console = new ConsoleApplication();
            var service = new ConfigurationManager(console, console, confCache);

            service.InitializeData(Constants.DefaultPath);
            service.InitializeCommands();
        }
    }
}
