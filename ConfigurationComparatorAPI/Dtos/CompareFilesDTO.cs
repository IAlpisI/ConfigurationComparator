using Microsoft.AspNetCore.Http;

namespace ConfigurationComparatorAPI.Dtos
{
    public class CompareFilesDTO
    {
        public IFormFile Target { get; set; }
        public IFormFile Source { get; set; }
    }
}
