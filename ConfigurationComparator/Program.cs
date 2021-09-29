using ConfigurationComparator.ConfigurataionFacade;
using ConfigurationComparator.Logging;

namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new Console();
            var service = new ConfigurationService(console, console);

            service.InitializeData();
            service.InitializeCommands();
        }
    }
}
