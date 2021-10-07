using Microsoft.AspNetCore.Http;

namespace ConfigurationComparatorAPI.Interfaces
{
    public interface IFileService
    {
        bool TryUploadFiles(IFormFile sourceFile, IFormFile targetFile);
        bool ValidateFiles(string source, string target);
    }
}
