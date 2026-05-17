using Application.Interfaces.RpcClients;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

public class MailRpcClient : DotnetRpcClient, IMailRpcClient
{
    public MailRpcClient(IConfiguration configuration) 
        : base(configuration["RpcServices:MailService"] ?? throw new Exception("MailService URI not set")) { }

    public Task<RpcResult<DefaultRpcResponse>> SendMail(string email, string subject, string content, string token)
    {
        return SendRpcRequest<DefaultRpcResponse>(
            "SendMail",
            new Dictionary<string, object>
            {
                { "email", email },
                { "subject", subject },
                { "content", content }
            },
            token: token
        );
    }
}