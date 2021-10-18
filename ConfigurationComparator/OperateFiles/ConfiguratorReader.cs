using ConfigurationComparator.ConfigurationVisitor;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ConfigurationComparator
{
    public static class ConfiguratorReader
    {
        /// <summary>
        /// If file exists read the file
        /// </summary>
        /// <param name="path">Path of the file to read</param>
        /// <returns>A Collection of <see cref="ComparatorParameters"/></returns>
        public static IEnumerable<ConfigurationParameters> Read(string path)
        {
            var data = new List<ConfigurationParameters>();

            if (File.Exists(path))
            {
                ParseData(File.ReadAllLines(path), ref data);
            }

            return data;
        }

        /// <summary>
        /// Parse file lines based on split size
        /// </summary>
        /// <param name="lines">File lines to parse</param>
        /// <param name="conf">Configuration parameters</param>
        public static void ParseData(string[] lines, ref List<ConfigurationParameters> conf)
        {
            foreach (var line in lines)
            {
                var parameters = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var p in parameters)
                {
                    var temp = p.Split(':');
                    var values = temp.Length == 2 ? (temp[0], temp[1]) : (temp[0], string.Empty);
                    conf.Add(new ConfigurationParameters(values.Item1, values.Item2));
                }
            }
        }

        /// <summary>
        /// Extract file with .CFG extension
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Path of the newly created file</returns>
        public static string Decompose(string fileName, string path)
        {
            string newFileName = string.Empty;
            var filePath = Path.Combine(path, fileName);

            if (File.Exists(filePath))
            {
                newFileName = filePath[..^4];

                using FileStream inputStream = new(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                using FileStream outputStream = new(newFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                using GZipStream gzip = new(inputStream, CompressionMode.Decompress);
                gzip.CopyTo(outputStream);
            }

            return newFileName;
        }
    }
}
