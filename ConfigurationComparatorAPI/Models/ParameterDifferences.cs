using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;

namespace ConfigurationComparator.Models
{
    public class ParameterDifferences
    {
        public ConfigurationParameters Source { get; set; }
        public ConfigurationParameters Target { get; set; }
        public Status Status { get; set; } 
    }
}
