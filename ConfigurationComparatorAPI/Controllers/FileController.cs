using ConfigurationComparator;
using ConfigurationComparator.ConfigurataionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Upload(IFormFile source, IFormFile target)
        {

            var fileUpload = ConfigurationService.TryUploadFiles(source, target, Constants.CFGFileExtension);

            if (fileUpload)
            {
                return Ok(_configurationService.GetResponse(source, target));
            }

            return BadRequest(new { message = "Invalid file extension" });
        }
    }
}
