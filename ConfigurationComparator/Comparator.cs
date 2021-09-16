using System;
using System.Collections.Generic;

namespace ConfigurationComparator
{
    public class Comparator
    {
        public static IEnumerable<Comparision> Compare(Dictionary<string, string> source, Dictionary<string, string> target)
        {
            var data = new List<Comparision>();

            foreach(var s in source)
            {
                var sourceKey = s.Key;
                var sourceValue = s.Value;

                if(!int.TryParse(sourceKey, out _))
                {
                    continue;
                }

                var comp = new Comparision(sourceKey, sourceValue);

                if (target.ContainsKey(sourceKey))
                {
                    var status = sourceValue == target[sourceKey] ? Status.Unchanged : Status.Modified;

                    comp.SetTarget(target[sourceKey]);
                    comp.SetStatus(status);
                    data.Add(comp);

                    continue;
                }

                comp.SetStatus(Status.Removed);
                data.Add(comp);
            }

            foreach(var t in target)
            {
                var targetKey = t.Key;
                var targetValue = t.Value;

                if (!int.TryParse(targetKey, out _))
                {
                    continue;
                }

                var comp = new Comparision(targetKey, targetValue, target[targetKey]);

                if(!source.ContainsKey(targetKey))
                {
                    comp.SetStatus(Status.Added);
                    data.Add(comp);
                }
            }

            return data;
        }

    }
}
