using System.Collections.Generic;
using System.IO;
using ConfigurationComparator.ConfigurataionFacade;
using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using ConfigurationComparator.Extensions;

namespace ConfigurationComparator
{
    public class Main
    {
        private readonly Facade facade;
        private string SourceFilePath { get; set; }
        private string TargetFilePath { get; set; }

        private readonly List<Status> Statuses = new() { Status.Added, Status.Modified, Status.Removed, Status.Unchanged };

        public Main(IConsole console)
        {
            facade = new Facade(console);
        }

        public void Run()
        {
            //LookForFile(FileType.Target);
            //LookForFile(FileType.Source);

            //var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(SourceFilePath));
            //var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(TargetFilePath));

            //var compHandler = new ConfiguratorHandler();
            //compHandler.Handle(sourceData, targetData);

            //var compared = compHandler.GetIntTypeData();
            //var sustained = compHandler.GetStringTypeData();

            facade.RunCommands();

            //bool run = true;
            //while (run)
            //{
            //    _console.PrintToConsole("F to filter \nW to view the files \nQ to finish " +
            //        "\nR to view report \nG to view records with string type ids " +
            //        "\nV to view records with int type ids");

            //    var command = _console.ReadInput();

            //    ActivateCommand(command, ref run, compared, sustained);
            //}
        }

        //private void ActivateCommand(string command, ref bool run, IEnumerable<ComparatorParameters> compared, IEnumerable<ConfigurationParameters> sustained)
        //{
        //    switch (command)
        //    {
        //        case "F":
        //            FilterData(compared);
        //            break;
        //        case "W":
        //            _console.PrintToConsole($"Source file - {SourceFilePath} \nTarget file - {TargetFilePath}");
        //            break;
        //        case "Q":
        //            run = false;
        //            break;
        //        case "R":
        //            Print(compared.GetReport());
        //            break;
        //        case "V":
        //            Print(compared);
        //            break;
        //        case "G":
        //            Print(sustained);
        //            break;
        //        default:
        //            break;
        //    }
        //    _console.PrintToConsole();
        //}

        //private void FilterData(IEnumerable<ComparatorParameters> data)
        //{
        //    List<Status> filter = new();
        //    int filterNumber = 4;

        //    _console.PrintToConsole("Write id");
        //    var id = _console.ReadInput();
        //    _console.PrintToConsole("Select filters \n0 - Added \n1 - Modified \n2 - Removed \n3 - Unchanged ");
        //    var filters = _console.ReadInput();

        //    for(int x=0;x<filterNumber;x++)
        //    {
        //        if (filters.Contains(x.ToString()))
        //        {
        //            filter.Add(Statuses[x]);
        //        }
        //    }

        //    Print(data.Filter(filter, id));
        //}

        //private void Print<T>(IEnumerable<T> data)
        //{
        //    foreach (var d in data)
        //    {
        //        _console.PrintToConsole(d.ToString());
        //    }
        //    _console.PrintToConsole();
        //}
    }
}
