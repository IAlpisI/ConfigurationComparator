using System.Collections.Generic;
using static System.Console;

namespace ConfigurationComparator.Logging
{
    public class Console : IMessageWriter, IMessageReader
    {

        public string Read()
        {
            return ReadLine();
        }

        public void Write(string value)
        {
            WriteLine(value);
        }

        public void Write()
        {
            WriteLine();
        }

        public void WriteData<T>(IEnumerable<T> data)
        {
            foreach (var d in data)
            {
                WriteLine(d.ToString());
            }
            WriteLine();
        }
    }
}
