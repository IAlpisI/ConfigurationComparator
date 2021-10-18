using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Models;
using System.Collections.Generic;
using static System.Console;

namespace ConfigurationComparator.Logging
{
    public class ConsoleApplication : IWriter, IReader
    {

        public string Read()
        {
            return ReadLine();
        }

        public void Write(string value)
        {
            WriteLine(value);
        }

        public void WriteData(IEnumerable<ComparatorParameters> comp)
        {
            foreach (var c in comp)
            {
                WriteLine(c.ToString());
            }
            WriteLine();
        }

        public void WriteData(IEnumerable<Report> reports)
        {
            foreach (var r in reports)
            {
                WriteLine(r.ToString());
            }
            WriteLine();
        }
    }
}
