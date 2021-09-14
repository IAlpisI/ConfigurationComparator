using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConfigurationComparator
{
    public class Main
    {
        private string SourceFilePath { get; set; }
        private string TargetFilePath { get; set; }
        private readonly List<Status> Statuses = new() { Status.Added, Status.Modified, Status.Removed, Status.Unchanged };
        private IEnumerable<Comparision> Data { get; set; }

        public void Run()
        {
            bool run = true;

            LookForFile("Source");
            LookForFile("Target");

            var sourceData = ConfiguratorReader.Read(Constant.SourceFilePath);
            var targetData = ConfiguratorReader.Read(Constant.TargetFilePath);
            Data = Comparator.Compare(sourceData, targetData);

            PrintData();

            while (run)
            {
                Console.WriteLine("F to filter \nW to view files \nQ to finish \nR to view report");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "F":
                        FilterData();
                        break;
                    case "W":
                        Console.WriteLine($"Source file - {SourceFilePath} \n Target file - {TargetFilePath}");
                        break;
                    case "Q":
                        run = false;
                        break;
                    case "R":
                        Comparision.PrintReport(Data);
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
        }

        public void FilterData()
        {
            List<Status> filter = new();

            Console.WriteLine("Write id");
            var id = Console.ReadLine();
            Console.WriteLine("Select filters \n0 - Added \n1 - Modified \n2 - Removed \n3 - Unchanged ");
            var filters = Console.ReadLine();

            for(int x=0;x<4;x++)
            {
                if (filters.Contains(x.ToString()))
                {
                    filter.Add(Statuses[x]);
                }
            }

            Comparision.Filter(Data, id, filter);
        }

        public void LookForFile(string FileType)
        {
            while(true)
            {
                Console.WriteLine($"Write the {FileType} file name in the data folder");
                var filePath = Console.ReadLine();

                if (File.Exists(Constant.defaultPath + filePath))
                {
                    switch (FileType)
                    {
                        case "Source":
                            SourceFilePath = filePath;
                            break;
                        case "Target":
                            TargetFilePath = filePath;
                            break;
                        default:
                            break ;
                    }
                    break;
                }
                Console.WriteLine("File not found");
            }
        }

        public void PrintData()
        {
            foreach (var d in Data)
            {
                Console.WriteLine(d.ToString());
            }
            Console.WriteLine();
        }
    }
}
