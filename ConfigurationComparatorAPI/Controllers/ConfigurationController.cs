using ConfigurationComparator;
using ConfigurationComparator.ConfigurataionService;
using ConfigurationComparator.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationComparatorAPI.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ConfigurationService _configurationService;
        public ConfigurationController()
        {
            _configurationService = new ConfigurationService();
        }

        [HttpPost]
        public IActionResult FilterBydId(FilterByIdDTO filterById)
        {
            if (_configurationService.FilesArePresent(filterById.SourceFileName, filterById.TargetFileName,
                Constants.CFGFileExtension, Constants.APIDefaultPath))
            {
                return Ok();
            }

            return NotFound(new { message = "File not found" });
        }

        [HttpPost]
        public IActionResult FilterByStatus(FilterByStatusDTO filterByStatus)
        {
            if (_configurationService.FilesArePresent(filterByStatus.SourceFileName, filterByStatus.TargetFileName,
                Constants.CFGFileExtension, Constants.APIDefaultPath))
            {
                return Ok();
            }

            return NotFound(new { message = "File not found" });
        }
    }
}
