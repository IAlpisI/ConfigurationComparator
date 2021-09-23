using System.Collections.Generic;
using static System.Console;

namespace ConfigurationComparator
{
    public class Console : IDataProcess
    {

        public string ReadInput()
        {
            return ReadLine();
        }

        public void Print(string value)
        {
            WriteLine(value);
        }

        public void Print()
        {
            WriteLine();
        }

        public void PrintListOfData<T>(IEnumerable<T> data)
        {
            foreach (var d in data)
            {
                WriteLine(d.ToString());
            }
            WriteLine();
        }
    }
}
