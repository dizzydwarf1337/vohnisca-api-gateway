namespace Application.Interfaces.RpcClients;

public class RpcResult<T>
{
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public string? Error { get; set; }
    public int StatusCode { get; set; } = 500;

    public static RpcResult<T> Success(T data) =>
        new()
        {
            IsSuccess = true,
            Data = data,
            StatusCode = 200,
        };

    public static RpcResult<T> Failure(string? error, int statusCode = 500) =>
        new()
        {
            IsSuccess = false,
            Error = error,
            StatusCode = statusCode,
        };
}

public record DefaultRpcResponse(bool IsSuccess = true, string? Error = null, int StatusCode = 200);