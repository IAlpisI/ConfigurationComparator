using System;
using System.IO;

namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new FileReader();

            var sourceData = temp.Read(Constant.SourceFilePath);
            var targetData = temp.Read(Constant.TargetFilePath);

            foreach(var s in sourceData)
            {
                Console.WriteLine(s.Key+" "+s.Value);
            }

            foreach (var s in targetData)
            {
                Console.WriteLine(s.Key + " " + s.Value);
            }

            var comparator = new Comparator();
            var data = comparator.Compare(sourceData, targetData);

            foreach(var d in data)
            {
                Console.WriteLine(d.ToString());
            }
        }
    }
}
