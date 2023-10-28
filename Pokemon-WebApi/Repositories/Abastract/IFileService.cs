namespace Pokemon_WebApi.Repository.Abastract;

public interface IFileService
{
    Tuple<int, string> SaveImage(IFormFile imageFile);
    bool DeleteImage(string imageFileName);
    Task<string> GetImageAsync(string imageFileName);
    Task<List<string>> GetAllImageAsync(List<string> imageFileName);
}
