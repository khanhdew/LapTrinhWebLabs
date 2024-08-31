namespace Lab.Services;

public interface IBufferFileUploadService
{
    Task<string> UploadFile(IFormFile file);
}