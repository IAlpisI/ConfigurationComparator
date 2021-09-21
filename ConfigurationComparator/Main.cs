﻿using System.Collections.Generic;
using System.IO;
using ConfigurationComparator.Enums;
using ConfigurationComparator.Extensions;
using ConfigurationComparator.Visitor;

namespace ConfigurationComparator
{
    public class Main
    {
        private readonly IConsole _console;
        private string SourceFilePath { get; set; }
        private string TargetFilePath { get; set; }

        private readonly List<Status> Statuses = new() { Status.Added, Status.Modified, Status.Removed, Status.Unchanged };

        public Main(IConsole console)
        {
            _console = console;
        }

        public void Run()
        {
            LookForFile(FileType.Target);
            LookForFile(FileType.Source);

            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(SourceFilePath));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(TargetFilePath));

            var compHandler = new ConfiguratorHandler();
            compHandler.Handle(sourceData, targetData);

            var compared = compHandler.GetIntTypeData();
            var sustained = compHandler.GetStringTypeData();

            bool run = true;
            while (run)
            {
                _console.PrintToConsole("F to filter \nW to view the files \nQ to finish " +
                    "\nR to view report \nG to view records with string type ids " +
                    "\nV to view records with int type ids");

                var command = _console.ReadInput();

                ActivateCommand(command, ref run, compared, sustained);

                _console.PrintToConsole();
            }
        }

        private void ActivateCommand(string command, ref bool run, IEnumerable<ParamComparator> compared, IEnumerable<Param> sustained)
        {
            switch (command)
            {
                case "F":
                    FilterData(compared);
                    break;
                case "W":
                    _console.PrintToConsole($"Source file - {SourceFilePath} \nTarget file - {TargetFilePath}");
                    break;
                case "Q":
                    run = false;
                    break;
                case "R":
                    Print(compared.GetReport());
                    break;
                case "V":
                    Print(compared);
                    break;
                case "G":
                    Print(sustained);
                    break;
                default:
                    break;
            }
        }

        private void FilterData(IEnumerable<ParamComparator> data)
        {
            List<Status> filter = new();
            int filterNumber = 4;

            _console.PrintToConsole("Write id");
            var id = _console.ReadInput();
            _console.PrintToConsole("Select filters \n0 - Added \n1 - Modified \n2 - Removed \n3 - Unchanged ");
            var filters = _console.ReadInput();

            for(int x=0;x<filterNumber;x++)
            {
                if (filters.Contains(x.ToString()))
                {
                    filter.Add(Statuses[x]);
                }
            }

            //Comparison.Filter(Data, filter, id);
            data.Filter(filter, id);
        }

        private void LookForFile(FileType fileType)
        {
            while(true)
            {
                _console.PrintToConsole($"Write the {fileType} file name in the data folder");
                var file = _console.ReadInput();
                var filePath = Constants.DefaultPath + file;

                if (File.Exists(filePath) && file[^4..].Equals(Constants.CFGFileExtension))
                {
                    switch (fileType)
                    {
                        case FileType.Source:
                            SourceFilePath = filePath;
                            break;
                        case FileType.Target:
                            TargetFilePath = filePath;
                            break;
                        default:
                            break ;
                    }
                    break;
                }
                _console.PrintToConsole("File not found");
            }
        }

        private void Print<T>(IEnumerable<T> data)
        {
            foreach(var d in data)
            {
                _console.PrintToConsole(d.ToString());
            }
            _console.PrintToConsole();
        }
    }
}
