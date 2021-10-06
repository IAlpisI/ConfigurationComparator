using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Extensions
{
    public static class FilterByStatusExtension
    {
        public static IEnumerable<ComparatorParameters> FilterByStatus(this IEnumerable<ComparatorParameters> comp, List<Status> statuses) =>
            comp.Where(x => x.IsStatusAvailable() && statuses.Contains(x.GetStatus()));
    }
}
