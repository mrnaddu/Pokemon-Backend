namespace Pokemon_WebApi.Models.Response;

public class ResponseValue<T>
{
    public bool StatusCode { get; set; }
    public string Message { get; set; }
    public T Value { get; set; }
    public string ImgUrl { get; set; }
}
