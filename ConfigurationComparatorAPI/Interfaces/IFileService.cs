using ConfigurationComparatorAPI.Models;
using Microsoft.AspNetCore.Http;

namespace ConfigurationComparatorAPI.Interfaces
{
    public interface IFileService
    {
        public bool TryUploadFiles(IFormFile sourceFile, IFormFile targetFile);
        public bool ValidateConfigurationFiles(ConfigurationFiles confFiles);
    }
}
