using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Extensions
{
    public static class FilterExtension
    {
        public static IEnumerable<ComparatorParameters> Filter(this IEnumerable<ComparatorParameters> comp, List<Status> filters, string Id)
        {
            if (filters is null || comp is null)
            {
                return new List<ComparatorParameters>();
            }

            return comp.Where(x => filters.Contains(x.Status) && x.Source.Id.Contains(Id));
        }
    }
}
