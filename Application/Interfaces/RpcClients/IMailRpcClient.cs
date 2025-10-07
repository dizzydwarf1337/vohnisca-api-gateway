using MediatR;

namespace Application.Interfaces.RpcClients;

public interface IMailRpcClient
{
    Task<RpcResult<SendMailResult>> SendMail(string to, string subject, string content);
}

public record SendMailResult(bool IsSuccess, string? Error);