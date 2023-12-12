namespace Image_upload.Interfaces
{
    public interface IImageServiceInterface
    {
        byte[] getImage(int id);
        public int UploadImage(byte[] image);
    }
}
