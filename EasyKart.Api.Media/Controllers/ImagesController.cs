using EasyKart.Api.Media.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyKart.Api.Media.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetImageAsync(string fileName)
        {
            var (content, contentType) = await _imageService.GetImageAsync(fileName);
            return File(content, contentType);
        }
    }
}
