using ConfigurationComparator.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace ConfigurationComparator.Dtos
{
    public class FilterDTO
    {
        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public string Id { get; set; }
        public List<Status> Statuses { get; set; }
    }
}
