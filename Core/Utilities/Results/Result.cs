namespace Core.Utilities.Results;

public class Result : IResult
{
    public Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public Result(bool isSuccess, string message) : this(isSuccess)
    {
        Message = message;
    }

    public string Message { get; }
    public bool IsSuccess { get; }
}