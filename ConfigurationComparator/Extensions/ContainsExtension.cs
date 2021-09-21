using ConfigurationComparator.ConfigurationVisitor;
using System.Collections.Generic;

namespace ConfigurationComparator.Extensions
{
    public static class ContainsExtension
    {
        public static bool TryToFindById(this IEnumerable<ConfigurationParameters> data, string id, out ConfigurationParameters val)
        {
            val = null;

            foreach(var d in data)
            {
                if (d.Id.Equals(id))
                {
                    val = d;
                    return true;
                }
            }

            return false;
        }
    }
}
