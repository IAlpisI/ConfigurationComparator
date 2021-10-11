using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Models;
using ConfigurationComparator.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Extensions
{
    public static class ReportExtension
    {
        /// <summary>
        /// Groups and gets count of each <see cref="Status"/>
        /// </summary>
        /// <param name="comp">Comparator parameters</param>
        /// <returns></returns>
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
