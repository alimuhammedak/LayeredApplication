namespace Core.Utilities.Results;

//Temel voidler için başlangıç
public interface IResult
{
    string Message { get; }
    bool IsSuccess { get; }
}