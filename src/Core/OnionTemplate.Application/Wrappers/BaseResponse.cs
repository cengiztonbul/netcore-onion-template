namespace OnionTemplate.Application.Wrappers;

public abstract class BaseResponse
{
    public bool SuccessStatus { get; set; }
    public string? Message { get; set; }

    protected BaseResponse(bool success, string? message)
    {
        SuccessStatus = success;
        Message = message;
    }
}
