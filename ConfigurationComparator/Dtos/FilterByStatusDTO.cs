using ConfigurationComparator.Enums;

namespace ConfigurationComparator.Dtos
{
    public class FilterByStatusDTO
    {
        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public Status Status { get; set; }
    }
}
