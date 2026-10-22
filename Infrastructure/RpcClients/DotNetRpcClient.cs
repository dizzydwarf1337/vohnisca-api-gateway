using System.Reflection;
using System.Text.Json.Serialization;
using Application.Interfaces.RpcClients;
using EdjCase.JsonRpc.Client;

namespace Infrastructure.RpcClients;

public abstract class DotnetRpcClient : BaseRpcClient
{
    protected DotnetRpcClient(string baseUrl) : base(baseUrl) { }

    protected override RpcParameters BuildParams(Dictionary<string, object>? parameters) =>
        parameters == null
            ? RpcParameters.Empty
            : new RpcParameters(new Dictionary<string, object> { { "request", parameters } });

    // Sends a command whose service-side result is Unit; only success/failure matters.
    protected async Task<RpcResult<bool>> SendCommand(string method, object payload, string token)
    {
        var result = await SendRpcRequest<DefaultRpcResponse>(method, ToDict(payload), token: token);
        return result.IsSuccess
            ? RpcResult<bool>.Success(true)
            : RpcResult<bool>.Failure(result.Error, ToHttpStatus(result.StatusCode));
    }

    // Sends a request and unwraps the service's RpcResponse<T> envelope.
    protected async Task<RpcResult<T>> SendData<T>(string method, object payload, string token)
    {
        var result = await SendRpcRequest<RpcDataResponse<T>>(method, ToDict(payload), token: token);
        if (!result.IsSuccess || result.Data is null)
            return RpcResult<T>.Failure(result.Error, ToHttpStatus(result.StatusCode));
        return RpcResult<T>.Success(result.Data.Data);
    }

    // The services report domain errors with the LanguageExt error code, which is 0 for a
    // plain Error.New("..."), and transport errors with JSON-RPC codes (negative). Neither
    // is a valid HTTP status, so map them before they become the gateway's response code.
    protected static int ToHttpStatus(int code) => code switch
    {
        >= 400 and <= 599 => code,
        0 => 400,
        -32601 => 404,
        -32602 => 422,
        _ => 500
    };

    // Turns a request/anonymous payload into the parameter map. Native CLR values are
    // kept (the JSON-RPC client serializes them), and [JsonIgnore] members (Token/UserId)
    // are skipped so only the data fields cross the wire.
    protected static Dictionary<string, object> ToDict(object payload)
    {
        var dict = new Dictionary<string, object>();
        foreach (var prop in payload.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (prop.GetCustomAttribute<JsonIgnoreAttribute>() is not null) continue;
            var value = prop.GetValue(payload);
            if (value is null) continue;
            dict[char.ToLowerInvariant(prop.Name[0]) + prop.Name[1..]] = value;
        }
        return dict;
    }
}
