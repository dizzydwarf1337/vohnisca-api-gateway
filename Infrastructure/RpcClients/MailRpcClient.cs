using Application.Interfaces.RpcClients;
using EdjCase.JsonRpc.Client;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

public class MailRpcClient : BaseRpcClient, IMailRpcClient
{
    public MailRpcClient(IConfiguration configuration) 
        : base(configuration["RpcServices:MailService"] ?? throw new Exception("MailService URI not set")) { }
    
    public async Task<RpcResult<SendMailResult>> SendMail(string email, string subject, string content, string token)
    {
        var rpcClient = CreateRpcClient(token);
        
        var parameters = new RpcParameters(new Dictionary<string, object>
        {
            { "email", email },
            { "subject", subject },
            { "content", content }
        });
        
        var request = new RpcRequest(
            id: Guid.NewGuid().ToString(),
            method: "SendMail",
            parameters: parameters
        );
        
        var response = await rpcClient.SendAsync<SendMailResult>(request);
        
        if (response.HasError)
            return RpcResult<SendMailResult>.Failure(response.Error?.Message ?? "Unknown RPC error");
        
        if (!response.Result.IsSuccess)
            return RpcResult<SendMailResult>.Failure(response.Result.Error ?? "Operation failed");

        return RpcResult<SendMailResult>.Success(response.Result);
    }
}