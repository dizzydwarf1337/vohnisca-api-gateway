using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.Public.Auth.ConfirmEmail;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, ApiResponse<Unit>>
{
    private readonly IAuthRpcClient  _rpcClient;
    
    public ConfirmEmailCommandHandler(IAuthRpcClient rpcClient)
        => _rpcClient = rpcClient;
    
    public async Task<ApiResponse<Unit>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var result = await _rpcClient.ConfirmEmailAsync(request.UserMail, request.Token);
        return result.IsSuccess 
            ? ApiResponse<Unit>.Success(Unit.Value)
            : ApiResponse<Unit>.Failure(result.Error ?? "Error while confirming email");
    }
}