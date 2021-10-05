using ConfigurationComparator;
using ConfigurationComparator.ConfigurataionService;
using ConfigurationComparator.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConfigurationComparatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ConfigurationService _configurationService;
        public FileController()
        {
            _configurationService = new ConfigurationService();
        }


        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile source, IFormFile target)
        {

            var success = _configurationService.TryUploadFiles(source.FileName, target.FileName, Constants.CFGFileExtension);

            if (success)
            {
                return Ok();
            }

            return BadRequest(new { message = "Invalid file extension" });
        }
    }
}
