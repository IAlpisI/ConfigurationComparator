using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Models;
using ConfigurationComparatorAPI.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Extensions
{
    public static class GetComparatorResponseDTOExtension
    {
        public static ComparatorResponseDTO GetComparatorDTO(this IEnumerable<ComparatorParameters> comp, IEnumerable<ComparatorParameters> compString, string source, string target) =>
            new()
            {
                SourceFileName = source,
                TargetFileName = target,
                FileParameters = compString.Where(x => !x.IsStatusAvailable()),
                CompareParameters = comp
                                    .Where(x => x.IsStatusAvailable())
                                    .Select(x => new ParameterDifferences {
                                        Source = x.Source,
                                        Target = x.Target,
                                        Status = x.GetStatus()
                                    })
            };
    }
}
