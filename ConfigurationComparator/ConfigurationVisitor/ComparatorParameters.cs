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

        /// <summary>
        /// Get <see cref="Status"/> based on Id type
        /// </summary>
        /// <returns> The value of <see cref="Status"/></returns>
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

        /// <summary>
        /// Check whenever <see cref="Status"/> is available for current value
        /// </summary>
        /// <returns>True if <see cref="Status"/> is available; otherwise, false</returns>
        public bool IsStatusAvailable() => int.TryParse(Source.Id, out _) || int.TryParse(Target.Id, out _);

        public override string ToString()
        {
            return $"{Source.Id} {Source.Value} {Target.Id} {Target.Value} {(IsStatusAvailable() ? GetStatus().ToString() : string.Empty)}";
        }
    }
}