namespace EasyKart.Api.Media.Services
{
    public interface IImageService
    {
        Task<(Byte[] Content, string ContentType)> GetImageAsync(string fileName);
    }
}
