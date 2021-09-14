namespace ConfigurationComparator
{
    public class Comparision
    {
        public string Id { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public Status Status { get; set; }

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
