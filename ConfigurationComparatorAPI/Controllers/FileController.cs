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
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
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
                return Ok();
            }

            return BadRequest(new { message = "Invalid file extension" });
        }
    }
}
