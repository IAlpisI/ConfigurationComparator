namespace ConfigurationComparator.ConfigurationVisitor
{
    public class ConfigurationParameters
    {
        public string Id { get; }
        public string Value { get; }
        public ConfigurationParameters()
        {
            Id = string.Empty;
            Value = string.Empty;
        }
        public ConfigurationParameters(string id, string value) => (Id, Value) = (id, value);
        public override string ToString() => $"{Id} {Value}";
    }
}
