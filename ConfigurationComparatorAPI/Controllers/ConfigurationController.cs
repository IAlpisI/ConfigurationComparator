using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationComparatorAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ConfigurationService _configurationService;
        public ConfigurationController()
        {
            _configurationService = new ConfigurationService(Constants.APIDefaultPath, Constants.CFGFileExtension);
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
