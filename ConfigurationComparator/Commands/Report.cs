using ConfigurationComparator.Enums;

namespace ConfigurationComparator.Commands
{
    public class Report
    {
        private readonly Status Status;
        private readonly int Count;

        public Report(Status s, int c) => (Status, Count) = (s, c);

        public override string ToString() => $"{Status} {Count}";
    }
}
