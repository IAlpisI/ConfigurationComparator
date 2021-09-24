using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;

namespace ConfigurationComparator.ConfigurationHandler
{
    public class ComparatorParameters
    {
        public ConfigurationParameters Source { get; }
        public ConfigurationParameters Target { get; }

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
            if (Source.Id.Equals(Target.Id))
            {
                return Source.Value.Equals(Target.Value) ? Status.Unchanged : Status.Modified;
            }

            if (Source.Id != string.Empty && !Source.Id.Equals(Target.Id))
            {
                return Status.Removed;
            }

            return Status.Added;
        }
        public bool IsStatusAvailable() => int.TryParse(Source.Id, out _) || int.TryParse(Target.Id, out _);
        public override string ToString()
        {
            return $"{Source.Id} {Source.Value} {Target.Id} {Target.Value} {(IsStatusAvailable() ? GetStatus().ToString() : string.Empty)}";
        }
    }
}