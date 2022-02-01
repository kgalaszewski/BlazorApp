using Microsoft.AspNetCore.Components.Forms;

namespace PocketAnalyzerServer.Services;

public interface IImageUploadService
{
    Task<string> UploadImage(IBrowserFile image);

    bool DeleteImage(string imageName);
}