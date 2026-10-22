using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.RemoveSceneToken;

public class RemoveSceneTokenCommandHandler : IRequestHandler<RemoveSceneTokenCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public RemoveSceneTokenCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(RemoveSceneTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RemoveSceneToken(request, request.Token!);
        return result.ToApiResponse(x => x, "Error removing the token");
    }
}
