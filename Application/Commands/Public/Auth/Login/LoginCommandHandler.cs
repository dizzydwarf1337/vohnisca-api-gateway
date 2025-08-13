using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.Public.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse<LoginResult>>
{
    private readonly IAuthRpcClient _authGrpcClient;
    
    public LoginCommandHandler(IAuthRpcClient authGrpcClient) => _authGrpcClient = authGrpcClient;
    
    public async Task<ApiResponse<LoginResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _authGrpcClient.LoginAsync(request.Email, request.Password);
        return ApiResponse<LoginResult>.Success(result);
    }
}