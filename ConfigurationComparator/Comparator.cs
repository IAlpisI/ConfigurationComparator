using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationComparator
{
    public class Comparator
    {
        public IEnumerable<Comparision> Compare(Dictionary<string, string> source, Dictionary<string, string> target)
        {
            var result = new List<Comparision>();

            foreach(var s in source)
            {
                var sourceKey = s.Key;
                var sourceValue = s.Value;

                var comp = new Comparision()
                {
                    Id = sourceKey,
                    Source = sourceValue,
                };

                if (target.ContainsKey(sourceKey))
                {
                    comp.SetTarget(target[sourceKey]);

                    if(sourceValue == target[sourceKey])
                    {
                        comp.SetStatus(Status.Unchanged);
                    } else
                    {
                        comp.SetStatus(Status.Modified);
                    }
                    result.Add(comp);
                    continue;
                } else
                {
                    comp.SetStatus(Status.Removed);

                    result.Add(comp);
                }
            }

            foreach(var t in target)
            {
                var targetKey = t.Key;
                var comp = new Comparision()
                {
                    Id = targetKey,
                    Source = t.Value,
                    Target = target[targetKey],
                };

                if(!source.ContainsKey(targetKey))
                {
                    comp.SetStatus(Status.Added);
                    result.Add(comp);
                }
            }

            return result;
        }
    }
}
