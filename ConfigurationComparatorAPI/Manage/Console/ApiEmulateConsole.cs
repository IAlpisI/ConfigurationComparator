using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Logging;
using ConfigurationComparator.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparatorAPI.Manage.Console
{
    public class ApiEmulateConsole : IWriter, IReader
    {
        private readonly Queue<string> CommandMessages;
        private readonly Queue<string> WriteMessages;
        private IEnumerable<ComparatorParameters> Comp {get;set;}
        private IEnumerable<Report> Report { get; set; }

        public IEnumerable<ComparatorParameters> GetComparatorParametersData() => Comp;
        public IEnumerable<Report> GetReport() => Report;

        public ApiEmulateConsole()
        {
            CommandMessages = new();
            WriteMessages = new();
        }

        public string Read()
        {
            return CommandMessages.Dequeue();
        }

        public void Write(string value)
        {
            WriteMessages.Enqueue(value);
        }

        public void WriteData(IEnumerable<ComparatorParameters> comp)
        {
            Comp = comp.ToList();
        }

        public void WriteData(IEnumerable<Report> reports)
        {
            Report = reports.ToList();
        }

        public void AddCommand(string command)
        {
            CommandMessages.Enqueue(command);
        }
    }
}
