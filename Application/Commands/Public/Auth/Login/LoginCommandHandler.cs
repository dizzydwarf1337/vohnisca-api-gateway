using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.Public.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse<LoginCommand.Result>>
{
    private readonly IAuthRpcClient _authGrpcClient;
    
    public LoginCommandHandler(IAuthRpcClient authGrpcClient) => _authGrpcClient = authGrpcClient;
    
    public async Task<ApiResponse<LoginCommand.Result>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _authGrpcClient.LoginAsync(request.Email, request.Password);
        return result.Data is { AccessToken: not null, TokenType: not null, ExpiresIn: not null }
            ? ApiResponse<LoginCommand.Result>.Success(new LoginCommand.Result(result.Data.AccessToken, result.Data.TokenType, (result.Data.ExpiresIn ?? 0).ToString()))
            : ApiResponse<LoginCommand.Result>.Failure(result.Error ?? "Unknown error");
    }
}