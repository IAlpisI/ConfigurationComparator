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
                    var values = temp.Length == 2 ? (temp[0], temp[1]) : (temp[0], string.Empty);
                    data.Add(values.Item1, values.Item2);
                }
            }

            return data;
        }

        public static string Decompose(string path)
        {
            var newFileName = path[..^4]; 

            try
            {
                using FileStream inputStream = new(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                using FileStream outputStream = new(newFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                using GZipStream gzip = new(inputStream, CompressionMode.Decompress);
                gzip.CopyTo(outputStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while trying to open the file "+ex.Message);
            }

            return newFileName;
        }
    }
}
