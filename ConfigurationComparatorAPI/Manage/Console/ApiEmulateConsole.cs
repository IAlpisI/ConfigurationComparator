using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Logging;
using ConfigurationComparator.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparatorAPI.Manage.Console
{
    public class ApiEmulateConsole : IWriter, IReader
    {
        private readonly Queue<string> messages = new();
        private IEnumerable<ComparatorParameters> Comp {get;set;}
        private IEnumerable<Report> Reports { get; set; }

        public IEnumerable<ComparatorParameters> GetComparatorParametersData()
        {
            messages.Clear();

            return Comp;
        }
        public string Read()
        {
            return messages.Dequeue();
        }

        public void Write(string value)
        {
            messages.Enqueue(value);
        }

        public void WriteData(IEnumerable<ComparatorParameters> comp)
        {
            Comp = comp.ToList();
        }

        public void WriteData(IEnumerable<Report> reports)
        {
            Reports = reports.ToList();
        }
    }
}
