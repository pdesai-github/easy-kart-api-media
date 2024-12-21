
using Azure.Storage.Blobs;

namespace EasyKart.Api.Media.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration _configuration;
        private readonly string _storageConnectionString = "YourAzureStorageConnectionString";
        private readonly string _containerName = "your-container-name";

        public ImageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _storageConnectionString = _configuration["StorageConnectionString"];
            _containerName = _configuration["ContainerName"];
        }

        public async Task<(Byte[] Content, string ContentType)> GetImageAsync(string fileName)
        {
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(_storageConnectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                var response = await blobClient.DownloadAsync();
                var contentType = response.Value.ContentType;
                using (var memoryStream = new MemoryStream())
                {
                    await response.Value.Content.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    return (content, contentType);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
