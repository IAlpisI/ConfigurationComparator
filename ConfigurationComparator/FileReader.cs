using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationComparator
{
    class FileReader
    {
        public IDictionary<string, string> Read(string path)
        {
            var lines = File.ReadAllLines(path);
            var result = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var parameters = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var p in parameters)
                {
                    var temp = p.Split(':');
                    if (temp.Length == 2)
                    {
                        result.Add(temp[0], temp[1]);
                    } else
                    {
                        result.Add(temp[0], string.Empty);
                    }
                }
            }

            return result;
        }
    }
}
