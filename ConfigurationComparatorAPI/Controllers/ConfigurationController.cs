using ConfigurationComparator;
using ConfigurationComparator.Dtos;
using ConfigurationComparator.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationComparatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ConfigurationAPIService _configurationService;
        public ConfigurationController()
        {
            _configurationService = new ConfigurationAPIService(Constants.APIDefaultPath, Constants.CFGFileExtension);
        }

        [HttpGet("Filter")]
        public IActionResult FilterBydId([FromQuery] FilterDTO filter)
        {
            if (_configurationService.FilesArePresent(filter.SourceFileName, filter.TargetFileName))
            {
                return Ok(_configurationService.Filter(filter));
            }

            return NotFound(new { message = "File not found" });
        }
    }
}
