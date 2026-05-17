using System.Net.Http.Headers;
using Application.Interfaces.RpcClients;
using EdjCase.JsonRpc.Client;

namespace Infrastructure.RpcClients;

public abstract class BaseRpcClient
{
    private readonly string _baseUrl;

    protected BaseRpcClient(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    protected RpcClient CreateRpcClient(string? route = null, string? token = null)
    {
        var url = string.IsNullOrEmpty(route)
            ? _baseUrl
            : $"{_baseUrl.TrimEnd('/')}/{route.TrimStart('/')}";

        var builder = new HttpRpcClientBuilder(new Uri(url))
            .ConfigureHttp(opt =>
            {
                opt.Headers = new List<(string, string)>()
                    { new ValueTuple<string, string>("Accept", "application/json") };
            });

        if (!string.IsNullOrEmpty(token))
        {
            builder.UsingAuthHeader(new AuthenticationHeaderValue("Bearer", token));
        }

        return builder.Build();
    }

    protected async Task<RpcResult<T>> SendRpcRequest<T>(
        string method,
        Dictionary<string, object>? parameters = null,
        string? token = null,
        string? route = null,
        Func<T, string?>? getErrorMessage = null,
        Func<T, int>? getStatusCode = null)
    {
        try
        {
            var rpcClient = CreateRpcClient(route, token);
            var rpcParams = BuildParams(parameters);
            var request = new RpcRequest(Guid.NewGuid().ToString(), method, rpcParams);

            var response = await rpcClient.SendAsync<T>(request);

            if (response.HasError)
                return RpcResult<T>.Failure(
                    response.Error?.Message ?? "Unknown RPC error",
                    response.Error?.Code ?? 500);

            if (response.Result is DefaultRpcResponse rpcResp && !rpcResp.IsSuccess)
                return RpcResult<T>.Failure(rpcResp.Error ?? "Unknown error", rpcResp.StatusCode);

            if (getErrorMessage != null)
            {
                var errorMsg = getErrorMessage(response.Result);
                if (!string.IsNullOrEmpty(errorMsg))
                    return RpcResult<T>.Failure(errorMsg, getStatusCode?.Invoke(response.Result) ?? 400);
            }

            return RpcResult<T>.Success(response.Result);
        }
        catch (Exception ex)
        {
            return RpcResult<T>.Failure(ex.Message, 500);
        }
    }

    protected virtual RpcParameters BuildParams(Dictionary<string, object>? parameters) =>
        parameters == null ? RpcParameters.Empty : new RpcParameters(parameters);
}