namespace Infrastructure.RpcClients;

public abstract class LaravelRpcClient : BaseRpcClient
{
    protected LaravelRpcClient(string baseUrl) : base(baseUrl) { }
}
