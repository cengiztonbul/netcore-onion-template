namespace OnionTemplate.Application.Wrappers;

public class ServiceResponse<T> : BaseResponse where T: class
{
    public T? Value { get; set; }
    
    private ServiceResponse(T? value, bool success, string? message) : base (success, message)
    {
        Value = value;
    }

    public static ServiceResponse<T> Success(T value, string? message = null)
    {
        return new ServiceResponse<T>(value, true, message);
    }

    public static ServiceResponse<T> Failure(string? message = null)
    {
        return new ServiceResponse<T>(null, false, message);
    }
}
