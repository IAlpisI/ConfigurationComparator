namespace ConfigurationComparator
{
    public class SingleValue
    {
        private readonly string Id;
        private readonly string Value;

        public SingleValue(string k, string v) => (Id, Value) = (k, v);

        public override string ToString() => $"{Id} {Value}";
    }
}
