using EdjCase.JsonRpc.Client;

namespace Infrastructure.RpcClients;

public abstract class LaravelRpcClient : BaseRpcClient
{
    protected LaravelRpcClient(string baseUrl) : base(baseUrl) { }

    protected override RpcParameters BuildParams(Dictionary<string, object>? parameters) =>
        parameters == null
            ? RpcParameters.Empty
            : new RpcParameters(parameters);
}