using Image_upload.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Image_upload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase

    {
        private readonly IImageServiceInterface _imageService;
        public ImageController(IImageServiceInterface imageService)
        {
            _imageService = imageService;

        }
        [HttpPost("upload")]

        public async Task<ActionResult> UploadImage([FromForm] ImageUploadRequest image)
        {

            using var memoryStream = new MemoryStream();

            image.Image.CopyTo(memoryStream);

            byte[] imageByte = memoryStream.ToArray();

            int id = _imageService.UploadImage(imageByte);

            return Ok(id);

        }
        [HttpPost("{id}")]

        public async Task<ActionResult> DownloadImage( int id)
        {

            var image = _imageService.getImage(id);

            return File(image,"image/webp");

        }
    }
}
