using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationComparator.Extensions
{
    public static class PrintReportExtension
    {
        public static void PrintReport(this IEnumerable<Comparison> comp)
        {
            if (comp is null)
            {
                return;
            }

            //var reportValues = comp.GroupBy(x => x.Status).Select(c => new SingleValue(c.Key.ToString(), c.Count().ToString()));

            //foreach (var value in reportValues)
            //{
            //    Console.WriteLine(value);
            //}
        }
    }
}
