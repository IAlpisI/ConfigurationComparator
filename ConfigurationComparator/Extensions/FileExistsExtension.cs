using System.IO;

namespace ConfigurationComparator.Extensions
{
    public static class FileExistsExtension
    {
        /// <summary>
        /// Check if file exists and file extension match
        /// </summary>
        /// <param name="extension">Extension</param>
        /// <param name="defaultPath">Default path</param>
        /// <param name="file">File name</param>
        /// <returns>True if the file was found; otherwise, false</returns>
        public static bool CheckFile(this string extension, string defaultPath, string file) => 
                    File.Exists(Path.Combine(defaultPath, file)) &&
                    file.FileExtentionMatch(extension);           
    }
}
