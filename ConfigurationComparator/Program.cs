using System;
using System.Collections.Generic;

namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            //var status = new List<Status>() { Status.Added, Status.Modified, Status.Removed, Status.Unchanged };
            //var id = "700077";

            //var file = new ConfiguratorReader();
            //var comp = new Comparision();

            var main = new Main();
            main.Run();

            //var sourceData = file.Read(Constant.SourceFilePath);
            //var targetData = file.Read(Constant.TargetFilePath);
            //var test = file.Read("../../../Data/FMB001-default.cfg");

            //foreach(var s in sourceData)
            //{
            //    Console.WriteLine(s.Key+" "+s.Value);
            //}

            //foreach (var s in targetData)
            //{
            //    Console.WriteLine(s.Key + " " + s.Value);
            //}

            //var comparator = new Comparator();
            //var data = Comparator.Compare(sourceData, targetData);

            //Comparision.PrintReport(data);
            //Comparision.Filter(data, id, status);
        }
    }
}
