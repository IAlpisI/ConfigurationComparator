using static System.Console;
using System.Collections.Generic;

namespace ConfigurationComparator
{
    public class EnglishVisualization : IConsole
    {

        public void PrintData<T>(IEnumerable<T> data)
        {
            foreach (var d in data)
            {
                WriteLine(d.ToString());
            }
            WriteLine();
        }

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
    }
}
