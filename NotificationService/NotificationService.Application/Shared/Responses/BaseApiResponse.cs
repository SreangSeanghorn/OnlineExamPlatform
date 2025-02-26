namespace NotificationService.Application.Shared.Responses;

public class BaseApiResponse<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    
    public BaseApiResponse(int statusCode, string message, T data)
    {
        this.StatusCode = statusCode;
        this.Message = message;
        this.Data = data;
    }
}