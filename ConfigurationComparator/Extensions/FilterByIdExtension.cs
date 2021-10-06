using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Extensions
{
    public static class FilterByIdExtension
    {
        public static IEnumerable<ComparatorParameters> FilterById(this IEnumerable<ComparatorParameters> comp, string id) =>
            comp.Where(x => x.IsStatusAvailable() && x.Source.Id.Contains(id));
    }
}
