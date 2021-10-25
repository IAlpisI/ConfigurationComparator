﻿using ConfigurationComparator.ConfigurataionService;
using ConfigurationComparator.Logging;

namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new ConsoleApplication();
            var service = new ConfigurationManager(console, console);

            service.InitializeData(Constants.DefaultPath);
            service.InitializeCommands();
        }
    }
}
