using ConfigurationComparator.ConfigurataionFacade;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            //using IHost host = CreateHostBuilder(args).Build();

            var ev = new EnglishVisualization();
            var facade = new Facade(ev);

            facade.InitializeData();
            facade.RunCommands();
        }

        //static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureServices((_, services) =>
        //            services.AddTransient<IConsole, Facade>());
    }
}
