namespace Application.Interfaces.RpcClients;

public class RpcResult<T>
{
    public bool IsSuccess;
    public T? Data;
    public string? Error;

    public static RpcResult<T> Success(T data) =>
        new RpcResult<T>
        {
            IsSuccess = true,
            Data = data
        };

    public static RpcResult<T> Failure(string? error) =>
        new RpcResult<T>
        {
            IsSuccess = false,
            Error = error
        };
};