namespace Image_upload.Interfaces
{
    public interface IImageRepositoryInterface
    {
        byte [] getImage(int id);
        public int UploadImage(byte [] imageData);

    }
}
