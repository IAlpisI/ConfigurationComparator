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
    }
}
