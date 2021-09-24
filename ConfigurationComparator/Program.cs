using ConfigurationComparator.ConfigurataionFacade;


namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new Console();
            var service = new ConfigurationService(console);

            service.InitializeData();
            service.InitializeCommands();
        }
    }
}
