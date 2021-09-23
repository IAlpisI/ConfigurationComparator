using ConfigurationComparator.ConfigurataionFacade;

namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {

            var console = new Console();
            var facade = new Facade(console);

            facade.InitializeData();
            facade.InitializeCommands();
        }
    }
}
