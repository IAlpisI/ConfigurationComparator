using System.Collections.Generic;

namespace ConfigurationComparator
{
    public interface IConsole
    {
        public void PrintToConsole(string value);
        public string ReadInput();
        public void PrintData<T>(IEnumerable<T> data);
        public void PrintToConsole();
    }
}
