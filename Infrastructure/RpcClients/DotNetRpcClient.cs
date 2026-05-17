using EdjCase.JsonRpc.Client;

namespace Infrastructure.RpcClients;

public abstract class DotnetRpcClient : BaseRpcClient
{
    protected DotnetRpcClient(string baseUrl) : base(baseUrl) { }

    protected override RpcParameters BuildParams(Dictionary<string, object>? parameters) =>
        parameters == null
            ? RpcParameters.Empty
            : new RpcParameters(new Dictionary<string, object> { { "command", parameters } });
}