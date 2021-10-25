using ConfigurationComparator.Extensions;
using ConfigurationComparatorAPI.Interfaces;
using ConfigurationComparatorAPI.Manage.Cache;
using ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile;
using ConfigurationComparatorAPI.Manage.Files;
using ConfigurationComparatorAPI.Models;
using Microsoft.AspNetCore.Http;

namespace ConfigurationComparatorAPI.Services
{
    public class FileService : IFileService
    {
        private readonly IConfigurationFileCache _fileCahche;

        public FileService(IConfigurationFileCache fileCache)
        {
            _fileCahche = fileCache;
        }

        public bool TryUploadFiles(IFormFile source, IFormFile target)
        {
            if (source.FileName.FileExtentionMatch(Constants.CFGFileExtension) &&
                target.FileName.FileExtentionMatch(Constants.CFGFileExtension))
            {
                ConfigurationWriter.Write(source, Constants.APIDefaultPath);
                ConfigurationWriter.Write(target, Constants.APIDefaultPath);

                _fileCahche.AddConfigurationFileNames(CacheKeys.FileNames, new ConfigurationFiles
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
            Constants.CFGFileExtension.CheckFile(Constants.APIDefaultPath, confFiles.Source) &&
            Constants.CFGFileExtension.CheckFile(Constants.APIDefaultPath, confFiles.Target);
    }
}
