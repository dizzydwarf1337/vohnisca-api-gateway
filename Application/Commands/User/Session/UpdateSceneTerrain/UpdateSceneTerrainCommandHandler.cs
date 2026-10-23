using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.UpdateSceneTerrain;

public class UpdateSceneTerrainCommandHandler : IRequestHandler<UpdateSceneTerrainCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public UpdateSceneTerrainCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(UpdateSceneTerrainCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UpdateSceneTerrain(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing the terrain");
    }
}
