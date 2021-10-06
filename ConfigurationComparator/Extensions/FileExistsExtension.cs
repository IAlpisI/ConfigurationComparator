using System.IO;

namespace ConfigurationComparator.Extensions
{
    public static class FileExistsExtension
    {
        public static bool CheckFile(this string extension, string defaultPath, string file)
        {
            var filePath = Path.Combine(defaultPath, file);

            return File.Exists(filePath) && file.CheckFileExtention(extension);
        }
             
    }
}
