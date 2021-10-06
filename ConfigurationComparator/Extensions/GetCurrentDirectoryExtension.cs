using System.IO;

namespace ConfigurationComparator.Extensions
{
    public static class GetCurrentDirectoryExtension
    {
        public static string GetCurrentPath(this string fileName, string path) =>
            Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
    }
}
