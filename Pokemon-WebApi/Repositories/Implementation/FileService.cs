using Pokemon_WebApi.Repository.Abastract;

namespace Pokemon_WebApi.Repository.Implementation;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<FileService> _logger;
    public FileService(
        IWebHostEnvironment env,
        ILogger<FileService> logger)
    {
        _environment = env;
        _logger = logger;
    }

    public Tuple<int, string> SaveImage(IFormFile imageFile)
    {
        try
        {
            var contentPath = _environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads/img");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Check the allowed extenstions
            var ext = Path.GetExtension(imageFile.FileName);
            var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
            if (!allowedExtensions.Contains(ext))
            {
                string msg = string.Format("Only {0} extensions are allowed",
                    string.Join(",", allowedExtensions));
                return new Tuple<int, string>(0, msg);
            }
            string uniqueString = Guid.NewGuid().ToString();
            // we are trying to create a unique filename here
            var newFileName = uniqueString + ext;
            var fileWithPath = Path.Combine(path, newFileName);
            var stream = new FileStream(fileWithPath, FileMode.Create);
            imageFile.CopyTo(stream);
            stream.Close();
            return new Tuple<int, string>(1, newFileName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new Tuple<int, string>(0, "Error has occured");
        }
    }

    public bool DeleteImage(string imageFileName)
    {
        try
        {
            var contentPath = _environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads/img", imageFileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }

    public Task<string> GetImageAsync(string imageFileName)
    {
        string Imageurl = string.Empty;
        try
        {
            var contentPath = _environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads/img");
            if (Directory.Exists(path))
            {
                Imageurl = "https://localhost:7014/Resources/"+ imageFileName;
            }
            return Task.FromResult(Imageurl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public Task<List<string>> GetAllImageAsync(List<string> imageFileName)
    {
        List<string> Imageurl = new();
        try
        {
            var contentPath = _environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads/img");
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new(path);
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                foreach (FileInfo fileInfo in fileInfos)
                {
                    string filename = fileInfo.Name;
                    string imagepath = path + "\\" + filename;
                    if (Directory.Exists(imagepath))
                    {
                        string _Imageurl = "https://localhost:7014/Resources/" + imageFileName;
                        Imageurl.Add(_Imageurl);
                    }
                }
            }
            return Task.FromResult(Imageurl);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}
