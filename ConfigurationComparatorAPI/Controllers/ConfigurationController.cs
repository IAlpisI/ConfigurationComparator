using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Interfaces;
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
        public ConfigurationController(IConfigurationService configurationService,
                                       IFileService fileService)
        {
            _configurationService = configurationService;
            _fileService = fileService;
        }

        [HttpGet("Filter")]
        public IActionResult FilterBydId([FromQuery] FilterDTO filter)
        {
            if (_fileService.ValidateFiles(filter.SourceFileName, filter.TargetFileName))
            {
                return Ok(_configurationService.Filter(filter));
            }

            return NotFound(new { message = "File not found" });
        }
    }
}
