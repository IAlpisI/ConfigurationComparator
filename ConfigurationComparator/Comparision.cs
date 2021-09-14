using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator
{
    public class Comparision
    {
        private string Id { get; set; }
        private string Source { get; set; }
        private string Target { get; set; }
        private Status Status { get; set; }

        public Comparision(string id, string source) => (Id, Source) = (id, source);
        public Comparision(string id, string source, string target) => (Id, Source, Target) = (id, source, target);

        public void SetStatus(Status status) => Status = status;
        public void SetTarget(string target) => Target = target;
        public override string ToString() => $"{Id} {Source} {Target} {Status}";

        public static void PrintReport(IEnumerable<Comparision> comp)
        {
            var values = comp.GroupBy(x => x.Status).Select(c => new { Char=c.Key, Count=c.Count() });

            foreach(var v in values)
            {
                Console.WriteLine($"{v.Char} {v.Count}");
            }
        }

        public static void Filter(IEnumerable<Comparision> comp, string Id, List<Status> filters)
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
