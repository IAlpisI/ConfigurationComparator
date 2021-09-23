using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Extensions
{
    public static class ReportExtension
    {
        public static IEnumerable<Report> GetReport(this IEnumerable<ComparatorParameters> comp)
        {
            if (comp is null)
            {
                return new List<Report>();
            }

            return comp.Where(x => x.IsStatusAvailable())
                .GroupBy(x => x.GetStatus())
                .Select(c => new Report(c.Key, c.Count()));
        }
    }
}
