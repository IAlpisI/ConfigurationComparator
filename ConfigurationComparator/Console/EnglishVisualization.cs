using System.Collections.Generic;
using static System.Console;

namespace ConfigurationComparator
{
    public class EnglishVisualization : IConsole
    {

        public string ReadInput()
        {
            return ReadLine();
        }

        public void PrintToConsole(string value)
        {
            WriteLine(value);
        }

        public void PrintToConsole()
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
