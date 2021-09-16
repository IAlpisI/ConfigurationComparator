using System.Collections.Generic;

namespace ConfigurationComparator
{
    public class Comparator
    {
        public static (IEnumerable<Comparison>, IEnumerable<SingleValue>) Compare(Dictionary<string, string> source, Dictionary<string, string> target)
        {
            var dataWithIntTypeIds = new List<Comparison>();
            var dataWithStringTypeIds = new List<SingleValue>();

            foreach(var s in source)
            {
                if(!int.TryParse(s.Key, out _))
                {
                    dataWithStringTypeIds.Add(new SingleValue(s.Key, s.Value));
                    continue;
                }

                var comp = new Comparison(s.Key, s.Value);

                if (target.ContainsKey(s.Key))
                {
                    var status = s.Value == target[s.Key] ? Status.Unchanged : Status.Modified;

                    comp.SetTarget(target[s.Key]);
                    comp.SetStatus(status);
                    dataWithIntTypeIds.Add(comp);

                    continue;
                }

                comp.SetStatus(Status.Removed);
                dataWithIntTypeIds.Add(comp);
            }

            foreach(var t in target)
            {
                if (!int.TryParse(t.Key, out _))
                {
                    dataWithStringTypeIds.Add(new SingleValue(t.Key, t.Value));
                    continue;
                }

                var comp = new Comparison(t.Key, t.Value, target[t.Key]);

                if(!source.ContainsKey(t.Key))
                {
                    comp.SetStatus(Status.Added);
                    dataWithIntTypeIds.Add(comp);
                }
            }

            return (dataWithIntTypeIds, dataWithStringTypeIds);
        }
    }
}
