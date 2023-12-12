using Image_upload.Attributes;

namespace Image_upload
{
    public class ImageUploadRequest
    {
        [AllowedExtensions(".jpg", ".jpeg", ".png")]
        [MaxFileSize(10 * 1024 * 1024)]
        public IFormFile Image {  get; set; }

    }
}
