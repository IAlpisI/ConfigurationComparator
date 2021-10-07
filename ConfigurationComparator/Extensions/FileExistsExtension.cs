using System.IO;

namespace ConfigurationComparator.Extensions
{
    public static class FileExistsExtension
    {
        public static bool CheckFile(this string extension, string defaultPath, string file) => 
                    File.Exists(Path.Combine(defaultPath, file)) &&
                    file.FileExtentionMatch(extension);           
    }
}
