using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator
{
    public class Comparision
    {
        public string Id { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public Status Status { get; set; }

        public void SetStatus(Status status) => Status = status;
        public void SetTarget(string target) => Target = target;
        public override string ToString() => $"{Id} {Source} {Target} {Status}";

        public void PrintReport(IEnumerable<Comparision> comp)
        {
            var values = comp.GroupBy(x => x.Status).Select(c => new { Char=c.Key, Count=c.Count() });

            foreach(var v in values)
            {
                Console.WriteLine($"{v.Char} {v.Count}");
            }
        }

        public void Filter(IEnumerable<Comparision> comp, string Id, List<Status> filters)
        {
            var values = comp.Where(x => filters.Contains(x.Status) && x.Id.Contains(Id));

            foreach(var v in values)
            {
                Console.WriteLine(v);
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
