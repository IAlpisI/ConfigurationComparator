﻿using ConfigurationComparator;
using ConfigurationComparator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationComparatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ConfigurationAPIService _configurationService;
        public FileController()
        {
            _configurationService = new ConfigurationAPIService(Constants.APIDefaultPath, Constants.CFGFileExtension);
        }

        [HttpPost]
        public IActionResult Upload(IFormFile source, IFormFile target)
        {

            var fileUpload = _configurationService.TryUploadFiles(source, target);

            if (fileUpload)
            {
                return Ok(_configurationService.GetResponse(source, target));
            }

            return BadRequest(new { message = "Invalid file extension" });
        }
    }
}
