using Application.Interfaces.RpcClients;
using EdjCase.JsonRpc.Client;
using MediatR;

namespace Infrastructure.RpcClients;

public class MailRpcClient : IMailRpcClient
{
    private readonly RpcClient _rpcClient;
    
    public MailRpcClient(RpcClient rpcClient) => _rpcClient = rpcClient;
    
    public async Task<RpcResult<SendMailResult>> SendMail(string email, string subject, string content)
    {
        var parameters = new RpcParameters(new Dictionary<string, object>()
        {
            { "email", email },
            { "subject", subject },
            { "content", content },
        });
        
        var request = new RpcRequest(
            id: Guid.NewGuid().ToString(),
            method: "SendMail",
            parameters: parameters);
        
        var response = await _rpcClient.SendAsync<SendMailResult>(request);
        
        if (response.HasError || !response.Result.IsSuccess)
            return  RpcResult<SendMailResult>.Failure(response.Error?.Message);

        return RpcResult<SendMailResult>.Success(response.Result);
    }
}