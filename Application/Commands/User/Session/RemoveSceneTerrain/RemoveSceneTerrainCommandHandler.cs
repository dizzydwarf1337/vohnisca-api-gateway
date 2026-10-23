using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.RemoveSceneTerrain;

public class RemoveSceneTerrainCommandHandler : IRequestHandler<RemoveSceneTerrainCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public RemoveSceneTerrainCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(RemoveSceneTerrainCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RemoveSceneTerrain(request, request.Token!);
        return result.ToApiResponse(x => x, "Error removing the terrain");
    }
}
