using Microsoft.AspNetCore.Http;
using System.IO;

namespace ConfigurationComparator.OperateFiles
{
    public static class ConfigurationWriter
    {
        public static void Write(IFormFile file, string directoryPath)
        {
            var fullPath = Path.Combine(directoryPath, file.FileName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using var stream = new FileStream(fullPath, FileMode.Create);
            file.CopyToAsync(stream);
        }
    }
}
