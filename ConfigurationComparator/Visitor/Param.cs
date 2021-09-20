using ConfigurationComparator.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Visitor
{
    public class Param
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public Param(string id, string value) => (Id, Value) = (id, value);
    }

    public class ParamComparator
    {
        public Param Source { get; set; }
        public Param Target { get; set; }
        public Status Status { get; set; }

        public ParamComparator()
        {

        }
        public void SetTargetParam(Param target) => Target = target;
        public void SetSourceParam(Param source) => Source = source;
        public void SetStatus(Status status) => Status = status;
        public void SetTargetValue(string target) => Target.Value = target;
    }

    public interface IVisitor
    {
        public ParamComparator Visit(Param param, IEnumerable<Param> type);
    }

    public class SourceVisitor : IVisitor
    {
        public ParamComparator Visit(Param param, IEnumerable<Param> target)
        {
            var comp = new ParamComparator();

            if (!target.Contains(param.Id, out var val))
            {
                var status = param.Value == val.Value ? Status.Unchanged : Status.Modified;

                comp.SetTargetValue(val.Value);
                comp.SetStatus(status);
            }

            comp.SetStatus(Status.Removed);

            return comp;
        }
    }

    public class TargetVisitor : IVisitor
    {
        public ParamComparator Visit(Param param, IEnumerable<Param> source)
        {
            var comp = new ParamComparator();
            if (!source.Contains(param.Id, out var val))
            {
                comp.SetTargetParam(param);
                comp.SetSourceParam(new Param(val.Id, val.Value));
                comp.SetStatus(Status.Added);
            }

            return comp;
        }
    }

    public class Handler
    {
        public void Comapare(IEnumerable<Param> source, IEnumerable<Param> target)
        {
            var dataWithIntTypeIds = new List<ParamComparator>();
            var dataWithStringTypeIds = new List<Param>();
            var targetVisitor = new TargetVisitor();
            var sourceVisitor = new SourceVisitor();

            Compare(target, ref dataWithStringTypeIds, ref dataWithIntTypeIds, targetVisitor, source);
            Compare(source, ref dataWithStringTypeIds, ref dataWithIntTypeIds, sourceVisitor, target);
        }

        public void Compare(IEnumerable<Param> data, ref List<Param> dataWithStringTypeIds, ref List<ParamComparator> dataWithIntTypeIds, IVisitor visitor, IEnumerable<Param> toLook)
        {
            foreach (var d in data)
            {
                if (!int.TryParse(d.Id, out _))
                {
                    dataWithStringTypeIds.Add(new Param(d.Id, d.Value));
                    continue;
                }

                var temp = visitor.Visit(d, toLook);
                dataWithIntTypeIds.Add(temp);
            }
        }
    }
}
