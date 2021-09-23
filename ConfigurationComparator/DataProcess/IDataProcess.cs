using System.Collections.Generic;

namespace ConfigurationComparator
{
    public interface IDataProcess
    {
        public void Print(string value);
        public string ReadInput();
        public void Print();
        public void PrintListOfData<T>(IEnumerable<T> data);
    }
}
