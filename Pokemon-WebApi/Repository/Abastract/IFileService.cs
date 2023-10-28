namespace Pokemon_WebApi.Repository.Abastract;

public interface IFileService
{
    Tuple<int, string> SaveImage(IFormFile imageFile);
    bool DeleteImage(string imageFileName);
}
