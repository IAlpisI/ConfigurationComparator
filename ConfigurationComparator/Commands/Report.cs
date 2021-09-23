using ConfigurationComparator.Enums;

namespace ConfigurationComparator.Commands
{
    public class Report
    {
        private Status Status { get; set; }
        private int Count { get; set; }

        public Report(Status s, int c) => (Status, Count) = (s, c);

        public override string ToString() => $"{Status} {Count}";
    }
}
