using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.Admin.Mail;

public class SendMailCommandHandler : IRequestHandler<SendMailCommand, ApiResponse<Unit>>
{
    private readonly IMailRpcClient _mailRpcClient;
    
    public SendMailCommandHandler(IMailRpcClient mailRpcClient) =>  _mailRpcClient = mailRpcClient;
    
    public async Task<ApiResponse<Unit>> Handle(SendMailCommand request, CancellationToken cancellationToken)
    {
        var result = await _mailRpcClient.SendMail(request.Email, request.Subject, request.Content);
        return result.IsSuccess ? ApiResponse<Unit>.Success(Unit.Value) : ApiResponse<Unit>.Failure("error");
    }
}