using Application.Core.ApiResponse;
using Application.Interfaces.GrpcClients;
using MediatR;

namespace Application.Commands.Public.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse<LoginResult>>
{
    private readonly IAuthGrpcClient _authGrpcClient;
    
    public LoginCommandHandler(IAuthGrpcClient authGrpcClient) => _authGrpcClient = authGrpcClient;
    
    public async Task<ApiResponse<LoginResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return ApiResponse<LoginResult>.Success(await _authGrpcClient.LoginAsync(request.Email,request.Password));
    }
}