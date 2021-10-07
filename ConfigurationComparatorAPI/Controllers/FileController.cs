using ConfigurationComparatorAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationComparatorAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;
        private readonly IFileService _fileService;
        public FileController(IConfigurationService configurationService,
                              IFileService fileService)
        {
            _configurationService = configurationService;
            _fileService = fileService;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile source, IFormFile target)
        {
            if(source is null || target is null)
            {
                return BadRequest();
            }

            var fileUpload = _fileService.TryUploadFiles(source, target);

            if (fileUpload)
            {
                return Ok(_configurationService.GetComparatorResponse(source.FileName, target.FileName));
            }

            return BadRequest(new { message = "Invalid file extension" });
        }
    }
}
