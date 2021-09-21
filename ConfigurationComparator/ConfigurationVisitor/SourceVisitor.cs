using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Enums;
using ConfigurationComparator.Extensions;
using System.Collections.Generic;
using System;

namespace ConfigurationComparator.ConfigurationVisitor
{
    public class SourceVisitor : IVisitor
    {
        public void Visit(ConfigurationParameters param, IEnumerable<ConfigurationParameters> target, ref List<ComparatorParameters> data)
        {
            var comp = new ComparatorParameters(param);

            if (target.TryToFindById(param.Id, out var val))
            {
                var status = param.Value == val.Value ? Status.Unchanged : Status.Modified;

                comp.SetTargetParam(val);
                comp.SetStatus(status);
            }
            else
            {
                comp.SetStatus(Status.Removed);
            }

            data.Add(comp);
        }
    }
}
