using ConfigurationComparator.ConfigurationVisitor;
using System.Collections.Generic;

namespace ConfigurationComparator.Extensions
{
    public static class ContainsExtension
    {
        /// <summary>
        /// Check whenever collection has the id value
        /// </summary>
        /// <param name="data">The collection to look for the value</param>
        /// <param name="id">The id to look for in the list</param>
        /// <param name="val">value</param>
        /// <returns>True if id was found; Otherwise, false</returns>
        public static bool TryToFindById(this IEnumerable<ConfigurationParameters> data, string id, out ConfigurationParameters val)
        {
            val = new ConfigurationParameters();

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
