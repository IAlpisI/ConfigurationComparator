using System.Collections.Generic;

namespace ConfigurationComparator
{
    public class Comparator
    {
        /// <summary>
        ///The method compares values in both files on certain conditions:
        ///If source file ID matches target file ID and values are equal, mark it as unchanged.
        ///If source file ID matches target file ID  and values are distinct, mark it as modifies.
        ///If the source file ID doesn't exist in the target file, mark it as removed.
        ///If the target file ID doesn't exist in the source file, mark it as Added.
        /// </summary>
        /// <param name="source">Source file data</param>
        /// <param name="target">Target file data</param>
        /// <returns>
        ///IEnumerable<Comparison> returns data that only contains int type IDs
        ///IEnumerable<SingleValue> returns data that only contains string type IDs
        /// </returns>
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
