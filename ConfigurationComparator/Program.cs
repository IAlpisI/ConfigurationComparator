using System;
using System.Collections.Generic;

namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var status = new List<Status>() { Status.Added, Status.Modified, Status.Removed, Status.Unchanged };
            var id = "700077";

            var file = new FileReader();
            var comp = new Comparision();

            var sourceData = file.Read(Constant.SourceFilePath);
            var targetData = file.Read(Constant.TargetFilePath);

            //foreach(var s in sourceData)
            //{
            //    Console.WriteLine(s.Key+" "+s.Value);
            //}

            //foreach (var s in targetData)
            //{
            //    Console.WriteLine(s.Key + " " + s.Value);
            //}

            var comparator = new Comparator();
            var data = comparator.Compare(sourceData, targetData);

            comp.PrintReport(data);
            comp.Filter(data, id, status);
        }
    }
}
