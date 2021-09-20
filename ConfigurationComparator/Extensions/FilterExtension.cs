using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationComparator.Extensions
{
    public static class FilterExtension
    {
        public static void Filter(this IEnumerable<Comparison> comp, string Id, List<Status> filters)
        {
            if (filters is null || comp is null)
            {
                return;
            }

            //var filteredData = comp.Where(x => filters.Contains(x.Status) && x.Id.Contains(Id));

            //foreach (var fd in filteredData)
            //{
            //    Console.WriteLine(fd);
            //}
        }
    }
}
