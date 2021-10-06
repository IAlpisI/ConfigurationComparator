using Microsoft.AspNetCore.Http;
using System.IO;

namespace ConfigurationComparator.OperateFiles
{
    public static class ConfigurationWriter
    {
        public static void Write(IFormFile file, string path)
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), path);
            var filePath = Path.Combine(directoryPath, file.FileName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyToAsync(stream);
        }
    }
}
