using Image_upload.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Image_upload.Services
{
    public class ImageService : IImageServiceInterface
    {
        private readonly IImageRepositoryInterface _imageRepository;

        public ImageService(IImageRepositoryInterface imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public byte[] getImage(int id)
        {
            return _imageRepository.getImage(id);
        }

        public int UploadImage(byte[] image)
        {
            return _imageRepository.UploadImage(image);
        }
    }


}
