using System.Net.Http.Headers;
using System.Text;
using Application.Interfaces.RpcClients;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Infrastructure.RpcClients;

public abstract class BaseRpcClient
{
    private readonly string _baseUrl;

    protected BaseRpcClient(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    // N-05: requests are sent here, not by EdjCase's client — its HttpOptions.Headers never reach the request, so the
    // Idempotency-Key was lost on the way to every service. One HttpClient for the process (its sockets are pooled);
    // each request carries its own headers. Serialized as EdjCase did: Newtonsoft with its defaults (property names as
    // they are, enums as numbers) and the System.Text.Json values our DTOs carry.
    private static readonly HttpClient Http = new();
    private static readonly JsonSerializerSettings Json = new() { Converters = { new JsonElementConverter() } };

    protected async Task<RpcResult<T>> SendRpcRequest<T>(
        string method,
        Dictionary<string, object>? parameters = null,
        string? token = null,
        string? route = null,
        Func<T, string?>? getErrorMessage = null,
        Func<T, int>? getStatusCode = null,
        string? idempotencyKey = null)
    {
        try
        {
            var url = string.IsNullOrEmpty(route) ? _baseUrl : $"{_baseUrl.TrimEnd('/')}/{route.TrimStart('/')}";
            var body = JsonConvert.SerializeObject(new { id = Guid.NewGuid().ToString(), jsonrpc = "2.0", method, @params = BuildParams(parameters) }, Json);
            using var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new StringContent(body, Encoding.UTF8, "application/json") };
            if (!string.IsNullOrEmpty(token)) request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // The client's key for a command it may send again: the service tells a repeat by it.
            if (!string.IsNullOrEmpty(idempotencyKey)) request.Headers.Add("Idempotency-Key", idempotencyKey);

            using var answer = await Http.SendAsync(request);
            var text = await answer.Content.ReadAsStringAsync();
            if (!answer.IsSuccessStatusCode && !text.TrimStart().StartsWith('{'))
                throw new HttpRequestException($"The service answered {(int)answer.StatusCode} {answer.ReasonPhrase}");
            var reply = JObject.Parse(text);

            if (reply["error"] is JObject error)
                return RpcResult<T>.Failure(
                    error.Value<string>("message") ?? "Unknown RPC error",
                    error.Value<int?>("code") ?? 500);

            var result = reply["result"] is { Type: not JTokenType.Null } found ? found.ToObject<T>(JsonSerializer.Create(Json))! : default!;

            if (result is DefaultRpcResponse rpcResp && !rpcResp.IsSuccess)
                return RpcResult<T>.Failure(rpcResp.Error ?? "Unknown error", rpcResp.StatusCode);

            if (getErrorMessage != null)
            {
                var errorMsg = getErrorMessage(result);
                if (!string.IsNullOrEmpty(errorMsg))
                    return RpcResult<T>.Failure(errorMsg, getStatusCode?.Invoke(result) ?? 400);
            }

            return RpcResult<T>.Success(result);
        }
        catch (Exception ex)
        {
            // Unwind the inner exception chain so the real cause (e.g. connection refused, a bad response) and the
            // target service URL are visible to the caller.
            var causes = new List<string>();
            for (var e = ex; e is not null; e = e.InnerException)
                causes.Add(e.Message);

            var detail = $"{string.Join(" -> ", causes.Distinct())} [target: {_baseUrl}]";
            return RpcResult<T>.Failure(detail, 500);
        }
    }

    // The request's params: by name, or none (an empty list, as JSON-RPC writes it).
    protected virtual object BuildParams(Dictionary<string, object>? parameters) => parameters ?? (object)Array.Empty<object>();
}