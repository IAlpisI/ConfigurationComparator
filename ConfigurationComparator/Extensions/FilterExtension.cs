using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Extensions
{
    public static class FilterExtension
    {
        /// <summary>
        /// Filters the collection based on <see cref="Status"/> collection and id
        /// </summary>
        /// <param name="comp">Comparator parameters</param>
        /// <param name="filters">Status list</param>
        /// <param name="Id">Id</param>
        /// <returns>Filtered collection of <see cref="ComparatorParameters"/></returns>
        public static IEnumerable<ComparatorParameters> Filter(this IEnumerable<ComparatorParameters> comp, List<Status> filters, string Id) => 
            comp.Where(x => x.IsStatusAvailable() &&
                filters.Contains(x.GetStatus()) &&
                x.Source.Id.Contains(Id));
    }
}
