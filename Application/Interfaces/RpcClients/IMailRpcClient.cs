namespace Application.Interfaces.RpcClients;

public interface IMailRpcClient
{
    Task<RpcResult<DefaultRpcResponse>> SendMail(string to, string subject, string content, string token);
}
