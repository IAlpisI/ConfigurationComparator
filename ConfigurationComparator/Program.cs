using ConfigurationComparator.ConfigurataionFacade;


namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            #nullable enable
            var console = new Console();
            var facade = new ConfigurationService(console);

            facade.InitializeData();
            facade.InitializeCommands();
        }
    }
}
