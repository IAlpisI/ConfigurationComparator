using ConfigurationComparator.Cache;
using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Interfaces;
using ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationComparatorAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;
        private readonly IFileService _fileService;
        private readonly IConfFileNameCache _fileCache;
        public ConfigurationController(IConfigurationService configurationService,
                                       IFileService fileService,
                                       IConfFileNameCache fileCache)
        {
            _configurationService = configurationService;
            _fileService = fileService;
            _fileCache = fileCache;
        }

        [HttpGet("Filter")]
        public IActionResult Filter([FromQuery] FilterDTO filter)
        {
            if(!_fileCache.TryGetConfigurationFileName(CacheKeys.FileNames, out var confFiles))
            {
                return NotFound(new { message = "Configuration files not set" });
            }

            if (_fileService.ValidateConfigurationFiles(confFiles))
            {
                _configurationService.InitializeData(confFiles);
                return Ok(_configurationService.Filtered(filter, confFiles));
            }

            return NotFound(new { message = "File not found" });
        }
    }
}
