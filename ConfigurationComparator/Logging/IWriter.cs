using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Models;
using System.Collections.Generic;

namespace ConfigurationComparator.Logging
{
    public interface IWriter
    {
        public void Write(string value);
        public void WriteData(IEnumerable<ComparatorParameters> comp);
        public void WriteData(IEnumerable<Report> reports);
    }
}
