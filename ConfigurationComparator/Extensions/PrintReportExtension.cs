using ConfigurationComparator.Visitor;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Extensions
{
    public static class PrintReportExtension
    {
        public static IEnumerable<Param> GetReport(this IEnumerable<ParamComparator> comp)
        {
            if (comp is null)
            {
                return new List<Param>();
            }

            return comp.GroupBy(x => x.Status).Select(c => new Param(c.Key.ToString(), c.Count().ToString()));
        }
    }
}
