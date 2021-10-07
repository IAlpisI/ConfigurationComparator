using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Models;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Dtos
{
    public class ComparatorResponseDTO
    {
        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public IEnumerable<ComparatorParameters> FileParameters { get; set; }
        public IEnumerable<ParameterDifferences> CompareParameters { get; set; }
    }
}
