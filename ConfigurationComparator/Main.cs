using System;
using System.Collections.Generic;
using System.IO;

namespace ConfigurationComparator
{
    public class Main
    {
        private string SourceFilePath { get; set; }
        private string TargetFilePath { get; set; }

        private readonly List<Status> Statuses = new() { Status.Added, Status.Modified, Status.Removed, Status.Unchanged };
        private const string TargetFile = "Target";
        private const string SourceFile = "Source";

        public void Run()
        {
            bool run = true;

            LookForFile(SourceFile);
            LookForFile(TargetFile);

            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(SourceFilePath));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(TargetFilePath));

            var (Compared, Sustained) = Comparator.Compare(sourceData, targetData);

            while (run)
            {
                Console.WriteLine("F to filter \nW to view the files \nQ to finish " +
                    "\nR to view report \nG to view records with string type ids " +
                    "\nV to view records with int type ids");

                var command = Console.ReadLine();

                switch (command)
                {
                    case "F":
                        FilterData(Compared);
                        break;
                    case "W":
                        Console.WriteLine($"Source file - {SourceFilePath} \nTarget file - {TargetFilePath}");
                        break;
                    case "Q":
                        run = false;
                        break;
                    case "R":
                        Comparison.PrintReport(Compared);
                        break;
                    case "V":
                        Print(Compared);
                        break;
                    case "G":
                        Print(Sustained);
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
        }

        private void FilterData(IEnumerable<Comparison> Data)
        {
            List<Status> filter = new();
            int filterNumber = 4;

            Console.WriteLine("Write id");
            var id = Console.ReadLine();
            Console.WriteLine("Select filters \n0 - Added \n1 - Modified \n2 - Removed \n3 - Unchanged ");
            var filters = Console.ReadLine();

            for(int x=0;x<filterNumber;x++)
            {
                if (filters.Contains(x.ToString()))
                {
                    filter.Add(Statuses[x]);
                }
            }

            Comparison.Filter(Data, id, filter);
        }

        private void LookForFile(string FileType)
        {
            while(true)
            {
                Console.WriteLine($"Write the {FileType} file name in the data folder");
                var file = Console.ReadLine();
                var filePath = Constant.DefaultPath + file;

                if (File.Exists(filePath) && file[^4..].Equals(Constant.CFGFileExtension))
                {
                    switch (FileType)
                    {
                        case SourceFile:
                            SourceFilePath = filePath;
                            break;
                        case TargetFile:
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

        private static void Print<T>(IEnumerable<T> data)
        {
            foreach(var d in data)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine();
        }
    }
}
