namespace ConfigurationComparator
{
    public class Comparison
    {
        private string Id { get; set; }
        private string Source { get; set; }
        private string Target { get; set; }
        private Status Status { get; set; }

        public Comparison(string id, string source) => (Id, Source) = (id, source);
        public Comparison(string id, string source, string target) => (Id, Source, Target) = (id, source, target);

        public void SetStatus(Status status) => Status = status;
        public void SetTarget(string target) => Target = target;
        public override string ToString() => $"{Id} {Source} {Target} {Status}";
    }

    public enum Status
    {
        Removed,
        Added,
        Modified,
        Unchanged
    }
}
