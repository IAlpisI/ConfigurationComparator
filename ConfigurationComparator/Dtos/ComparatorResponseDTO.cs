using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Dtos
{
    public class ComparatorResponseDTO
    {
        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public IEnumerable<ComparatorParameters> ComparatorParameters { get; set; }
    }
}
