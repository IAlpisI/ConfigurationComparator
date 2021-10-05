using ConfigurationComparator.ConfigurationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationComparatorAPI.Dtos
{
    public class ComparatorResponseDTO
    {
        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public List<ComparatorParameters> ComparatorParameters { get; set; }
        public bool Success { get; set; }
    }
}
