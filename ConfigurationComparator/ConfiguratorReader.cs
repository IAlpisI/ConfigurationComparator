using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ConfigurationComparator
{
    class ConfiguratorReader
    {
        public static Dictionary<string, string> Read(string path)
        {
            var data = new Dictionary<string, string>();

            foreach (var line in File.ReadAllLines(path))
            {
                var parameters = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var p in parameters)
                {
                    var temp = p.Split(':');
                    if (temp.Length == 2)
                    {
                        data.Add(temp[0], temp[1]);
                    }
                    else
                    {
                        data.Add(temp[0], string.Empty);
                    }
                }
            }

            return data;
        }

        public static string Decompose(string path)
        {
            var newFile = path[..^4];

            try
            {
                using FileStream inputStream = new(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                using FileStream outputStream = new(newFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                using GZipStream gzip = new(inputStream, CompressionMode.Decompress);
                gzip.CopyTo(outputStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while trying to open the file "+ex);
            }

            return newFile;
        }
    }
}
