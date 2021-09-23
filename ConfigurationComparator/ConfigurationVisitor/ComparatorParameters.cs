using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using System;

namespace ConfigurationComparator.ConfigurationHandler
{
    public class ComparatorParameters
    {
        public ConfigurationParameters Source { get; set; }
        public ConfigurationParameters Target { get; set; }
        public Status Status { get; set; }

        public ComparatorParameters(ConfigurationParameters source)
        {
            Source = source;
            Target = new ConfigurationParameters();
        }

        public ComparatorParameters(ConfigurationParameters source, ConfigurationParameters target)
        {
            Source = source;
            Target = target;
        }

        public Status GetStatus()
        {
            //Console.WriteLine(" "+Target.Id);

            if (Source.Id.Equals(Target.Id))
            {
                return Source.Value.Equals(Target.Value) ? Status.Unchanged : Status.Modified;
            }

            if(Source.Id != string.Empty && !Source.Id.Equals(Target.Id))
            {
                return Status.Removed;
            }

            return Status.Added;
        }
        public bool IsStatusAvailable() => int.TryParse(Source.Id, out _) || int.TryParse(Target.Id, out _);
        public void SetTargetParam(ConfigurationParameters target) => Target = target;
        public void SetSourceParam(ConfigurationParameters source) => Source = source;
        public void SetStatus(Status status) => Status = status;
        public override string ToString() => $"{Source.Id} {Source.Value} {Target.Value} {Status}";
    }
}