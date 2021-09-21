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
        public override string ToString() => $"{Id} {Value}";
    }

    public class ParamComparator
    {
        public Param Source { get; set; }
        public Param Target { get; set; }
        public Status Status { get; set; }

        public ParamComparator(Param source) => (Source) = (source);
        public void SetTargetParam(Param target) => Target = target;
        public void SetSourceParam(Param source) => Source = source;
        public void SetStatus(Status status) => Status = status;
        public override string ToString() => $"{Source.Id} {Source.Value} {Target.Value} {Status}";
    }

    public interface IVisitor
    {
        public void Visit(Param param, IEnumerable<Param> type, ref List<ParamComparator> data);
    }

    public class SourceVisitor : IVisitor
    {
        public void Visit(Param param, IEnumerable<Param> target, ref List<ParamComparator> data)
        {
            var comp = new ParamComparator(param);

            if (target.Contains(param.Id, out var val))
            {
                var status = param.Value == val.Value ? Status.Unchanged : Status.Modified;

                comp.SetTargetParam(val);
                comp.SetStatus(status);
            } else
            {
                comp.SetStatus(Status.Removed);
            }

            data.Add(comp);
        }
    }

    public class TargetVisitor : IVisitor
    {
        public void Visit(Param param, IEnumerable<Param> source, ref List<ParamComparator> data)
        {
            if (!source.Contains(param.Id, out var val))
            {
                var comp = new ParamComparator(param);

                comp.SetSourceParam(val);
                comp.SetStatus(Status.Added);

                data.Add(comp);
            }
        }
    }

    public class ConfiguratorHandler
    {
        private List<ParamComparator> dataWithIntTypeIds;
        private readonly List<Param> dataWithStringTypeIds;

        public List<ParamComparator> GetIntTypeData() => dataWithIntTypeIds;
        public List<Param> GetStringTypeData() => dataWithStringTypeIds;

        public ConfiguratorHandler()
        {
            dataWithIntTypeIds = new List<ParamComparator>();
            dataWithStringTypeIds = new List<Param>();
        }
        public void Handle(IEnumerable<Param> source, IEnumerable<Param> target)
        {
            var targetVisitor = new TargetVisitor();
            var sourceVisitor = new SourceVisitor();

            Compare(target, targetVisitor, source);
            Compare(source, sourceVisitor, target);
        }

        public void Compare(IEnumerable<Param> data, IVisitor visitor, IEnumerable<Param> toLook)
        {
            foreach (var d in data)
            {
                if (!int.TryParse(d.Id, out _))
                {
                    dataWithStringTypeIds.Add(new Param(d.Id, d.Value));
                    continue;
                }

                visitor.Visit(d, toLook, ref dataWithIntTypeIds);
            }
        }
    }
}
