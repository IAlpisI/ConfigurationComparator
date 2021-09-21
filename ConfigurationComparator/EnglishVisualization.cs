using static System.Console;
using System.Collections.Generic;

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
    }
}
