using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Dtos
{
    public class ComparatorResponseDTO
    {
        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public List<ComparatorParameters> ComparatorParameters { get; set; }
    }
}
