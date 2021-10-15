using ConfigurationComparator.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConfigurationComparatorAPI.Dtos
{
    public class FilterDTO
    {
        //[Required]
        //public string SourceFileName { get; set; }
        //[Required]
        //public string TargetFileName { get; set; }
        public string Id { get; set; } = string.Empty;
        [Required]
        public List<Status> Statuses { get; set; }
    }
}
