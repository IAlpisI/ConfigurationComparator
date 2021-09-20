using ConfigurationComparator.Visitor;
using System;
using System.Collections.Generic;

namespace ConfigurationComparator.Extensions
{
    public static class ContainsExtension
    {
        public static bool Contains(this IEnumerable<Param> data, string id, out Param val)
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
