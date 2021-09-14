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

            foreach(var s in sourceData)
            {
                Console.WriteLine(s.Key+" "+s.Value);
            }
        }
    }
}
