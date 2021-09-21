using ConfigurationComparator.Visitor;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Extensions
{
    public static class FilterExtension
    {
        public static IEnumerable<ParamComparator> Filter(this IEnumerable<ParamComparator> comp, List<Status> filters, string Id)
        {
            if (filters is null || comp is null)
            {
                return new List<ParamComparator>();
            }

            return comp.Where(x => filters.Contains(x.Status) && x.Source.Id.Contains(Id));
        }
    }
}
