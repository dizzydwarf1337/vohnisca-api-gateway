using Application.Core.ApiResponse;

namespace Application.Interfaces.RpcClients;

public static class RpcResultExtensions
{
    public static ApiResponse<TOut> ToApiResponse<TIn, TOut>(this RpcResult<TIn> result, Func<TIn, TOut> mapper, string? defaultError = null)
    {
        return result.IsSuccess
            ? ApiResponse<TOut>.Success(mapper(result.Data!))
            : ApiResponse<TOut>.Failure(result.Error ?? defaultError ?? "Unknown error");
    }
}