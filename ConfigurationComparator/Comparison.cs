using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator
{
    public class Comparison
    {
        private string Id { get; set; }
        private string Source { get; set; }
        private string Target { get; set; }
        private Status Status { get; set; }

        public Comparison(string id, string source) => (Id, Source) = (id, source);
        public Comparison(string id, string source, string target) => (Id, Source, Target) = (id, source, target);

        public void SetStatus(Status status) => Status = status;
        public void SetTarget(string target) => Target = target;
        public override string ToString() => $"{Id} {Source} {Target} {Status}";

        public static void PrintReport(IEnumerable<Comparison> comp)
        {
            if(comp is null)
            {
                return;
            }

            var reportValues = comp.GroupBy(x => x.Status).Select(c => new SingleValue(c.Key.ToString(), c.Count().ToString()));

            foreach(var value in reportValues)
            {
                Console.WriteLine(value);
            }
        }

        public static void Filter(IEnumerable<Comparison> comp, string Id, List<Status> filters)
        {
            if (filters is null || comp is null)
            {
                return;
            }

            var filteredData = comp.Where(x => filters.Contains(x.Status) && x.Id.Contains(Id));

            foreach(var fd in filteredData)
            {
                Console.WriteLine(fd);
            }
        }
    }

    public enum Status
    {
        Removed,
        Added,
        Modified,
        Unchanged
    }
}
