using ConfigurationComparator.ConfigurationVisitor;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ConfigurationComparator
{
    public static class ConfiguratorReader
    {
        public static IEnumerable<ConfigurationParameters> Read(string path)
        {
            var data = new List<ConfigurationParameters>();

            if (File.Exists(path))
            {
                ParseData(File.ReadAllLines(path), ref data);
            }

            return data;
        }

        public static void ParseData(string[] lines, ref List<ConfigurationParameters> data)
        {
            foreach (var line in lines)
            {
                var parameters = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var p in parameters)
                {
                    var temp = p.Split(':');
                    var values = temp.Length == 2 ? (temp[0], temp[1]) : (temp[0], string.Empty);
                    data.Add(new ConfigurationParameters(values.Item1, values.Item2));
                }
            }
        }

        public static string Decompose(string path)
        {
            var newFileName = path[..^4];

            using FileStream inputStream = new(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using FileStream outputStream = new(newFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using GZipStream gzip = new(inputStream, CompressionMode.Decompress);
            gzip.CopyTo(outputStream);

            return newFileName;
        }
    }
}
