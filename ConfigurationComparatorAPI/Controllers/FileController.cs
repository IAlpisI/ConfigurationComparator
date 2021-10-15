using ConfigurationComparatorAPI.Interfaces;
using ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile;
using ConfigurationComparatorAPI.Models;
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
        private readonly IConfFileCache _fileCahche;
        public FileController(IFileService fileService,
                              IConfFileCache fileCache)
        {
            _fileService = fileService;
            _fileCahche = fileCache;
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
                _fileCahche.Add(new ConfigurationFiles
                {
                     Source = source.FileName,
                     Target = target.FileName
                });

                return Ok();
            }

            return BadRequest(new { message = "Invalid file extension" });
        }
    }
}
