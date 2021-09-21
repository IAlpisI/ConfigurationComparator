using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.ConfigurationVisitor;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Extensions
{
    public static class ReportExtension
    {
        public static IEnumerable<ConfigurationParameters> GetReport(this IEnumerable<ComparatorParameters> comp)
        {
            if (comp is null)
            {
                return new List<ConfigurationParameters>();
            }

            return comp.GroupBy(x => x.Status).Select(c => new ConfigurationParameters(c.Key.ToString(), c.Count().ToString()));
        }
    }
}
