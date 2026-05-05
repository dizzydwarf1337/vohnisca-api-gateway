using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.Public.Auth.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ApiResponse<RefreshTokenCommand.Result>>
{
    private readonly IAuthRpcClient _rpcClient;

    public RefreshTokenCommandHandler(IAuthRpcClient rpcClient)
        => _rpcClient = rpcClient;

    public async Task<ApiResponse<RefreshTokenCommand.Result>> Handle(RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _rpcClient.RefreshToken(request.RefreshToken);
        return result.ToApiResponse(data => new RefreshTokenCommand.Result(
                data.AccessToken,
                data.TokenType,
                data.ExpiresIn.ToString()
            )
        );
    }
}