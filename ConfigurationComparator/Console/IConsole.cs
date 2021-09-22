using System.Collections.Generic;

namespace ConfigurationComparator
{
    public interface IConsole
    {
        public void PrintToConsole(string value);
        public string ReadInput();
        public void PrintToConsole();
        public void PrintListOfData<T>(IEnumerable<T> data);
    }
}
