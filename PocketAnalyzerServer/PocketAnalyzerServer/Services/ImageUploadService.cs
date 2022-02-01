using Microsoft.AspNetCore.Components.Forms;

namespace PocketAnalyzerServer.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImage(IBrowserFile image)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(image.Name);
                var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                var imagesFolderName = "Images";
                var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\{imagesFolderName}";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, imagesFolderName, fileName);

                var memoryStream = new MemoryStream();
                await image.OpenReadStream().CopyToAsync(memoryStream);

                if (!Directory.Exists(folderDirectory))
                {
                    Directory.CreateDirectory(folderDirectory);
                }

                await using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                memoryStream.WriteTo(fileStream);

                return $"{imagesFolderName}/{fileName}";
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteImage(string imageName)
        {
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\Images\\{imageName}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
