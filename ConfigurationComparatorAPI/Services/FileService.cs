using ConfigurationComparator.Cache;
using ConfigurationComparator.Extensions;
using ConfigurationComparatorAPI.Interfaces;
using ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile;
using ConfigurationComparatorAPI.Manage.Files;
using ConfigurationComparatorAPI.Models;
using Microsoft.AspNetCore.Http;

namespace ConfigurationComparatorAPI.Services
{
    public class FileService : IFileService
    {
        private string Path { get; init; } = Constants.APIDefaultPath;
        private string Extension { get; init; } = Constants.CFGFileExtension;
        private readonly IConfFileNameCache _fileCahche;

        public FileService(IConfFileNameCache fileCache)
        {
            _fileCahche = fileCache;
        }

        public bool TryUploadFiles(IFormFile source, IFormFile target)
        {
            if (source.FileName.FileExtentionMatch(Extension) &&
                target.FileName.FileExtentionMatch(Extension))
            {
                ConfigurationWriter.Write(source, Path);
                ConfigurationWriter.Write(target, Path);

                _fileCahche.AddConfigurationFileName(CacheKeys.FileNames, new ConfigurationFiles
                {
                    Source = source.FileName,
                    Target = target.FileName
                });

                _fileCahche.Remove(CacheKeys.Source);
                _fileCahche.Remove(CacheKeys.Target);

                return true;
            }
            return false;
        }

        public bool ValidateConfigurationFiles(ConfigurationFiles confFiles) =>
            Extension.CheckFile(Path, confFiles.Source) &&
            Extension.CheckFile(Path, confFiles.Target);
    }
}
