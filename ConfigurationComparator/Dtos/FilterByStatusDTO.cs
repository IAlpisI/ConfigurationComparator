using ConfigurationComparator.Enums;
using System.Collections.Generic;

namespace ConfigurationComparator.Dtos
{
    public class FilterByStatusDTO
    {
        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public List<Status> Status { get; set; }
    }
}
