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

        [HttpGet("FilterById")]
        public IActionResult FilterBydId([FromQuery] FilterByIdDTO filterById)
        {
            if (_configurationService.FilesArePresent(filterById.SourceFileName, filterById.TargetFileName))
            {
                return Ok(_configurationService.GetFilteredById(filterById));
            }

            return NotFound(new { message = "File not found" });
        }

        [HttpGet("FilterByStatus")]
        public IActionResult FilterByStatus([FromQuery] FilterByStatusDTO filterByStatus)
        {
            if (_configurationService.FilesArePresent(filterByStatus.SourceFileName, filterByStatus.TargetFileName))
            {
                return Ok(_configurationService.GetFilteredByStatus(filterByStatus));
            }

            return NotFound(new { message = "File not found" });
        }
    }
}
