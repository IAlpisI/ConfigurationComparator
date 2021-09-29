using System.Collections.Generic;

namespace ConfigurationComparator.Logging
{
    public interface IMessageWriter
    {
        public void Write(string value);
        public void Write();
        public void WriteData<T>(IEnumerable<T> data);
    }
}
