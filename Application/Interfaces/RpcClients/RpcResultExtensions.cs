using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;

public static class RpcResultExtensions
{
    public static ApiResponse<TOut> ToApiResponse<TIn, TOut>(
        this RpcResult<TIn> result,
        Func<TIn, TOut> mapper,
        string? defaultError = null)
    {
        if (!result.IsSuccess || result.Data is null)
            return ApiResponse<TOut>.Failure(
                result.Error ?? defaultError ?? "Unknown error",
                result.StatusCode);

        var mapped = mapper(result.Data);
        return mapped is null
            ? ApiResponse<TOut>.Failure(defaultError ?? "Unknown error", 500)
            : ApiResponse<TOut>.Success(mapped);
    }
}