using ConfigurationComparator.Extensions;
using ConfigurationComparatorAPI.Interfaces;
using ConfigurationComparatorAPI.Manage.Files;
using Microsoft.AspNetCore.Http;
namespace ConfigurationComparatorAPI.Services
{
    public class FileService : IFileService
    {
        private string Path { get; init; } = Constants.APIDefaultPath;
        private string Extension { get; init; } = Constants.CFGFileExtension;

        public bool TryUploadFiles(IFormFile sourceFile, IFormFile targetFile)
        {
            if (sourceFile.FileName.FileExtentionMatch(Extension) &&
                targetFile.FileName.FileExtentionMatch(Extension))
                {
                    ConfigurationWriter.Write(sourceFile, Path);
                    ConfigurationWriter.Write(targetFile, Path);

                    return true;
                }
                return false;
        }

        public bool ValidateFiles(string source, string target) =>
            Extension.CheckFile(Path, source) && Extension.CheckFile(Path, target);
    }
}
