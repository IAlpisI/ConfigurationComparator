using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;

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
        public void SetTargetParam(ConfigurationParameters target) => Target = target;
        public void SetSourceParam(ConfigurationParameters source) => Source = source;
        public void SetStatus(Status status) => Status = status;
        public override string ToString() => $"{Source.Id} {Source.Value} {Target.Value} {Status}";
    }
}