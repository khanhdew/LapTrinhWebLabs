namespace Lab.Services;

public class BufferedFileUploadService: IBufferFileUploadService
{
    public async Task<string> UploadFile(IFormFile file)
    {
        string path = "";
        try
        {
            if (file.Length > 0)
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return "/uploads/" + file.FileName;
            }
            else
            {
                return "";
            }
        }
        catch (Exception ex)
        {
            throw new Exception("File Copy Failed", ex);
        }

    }
}