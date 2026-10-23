using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.IgniteSceneTerrain;

public class IgniteSceneTerrainCommandHandler : IRequestHandler<IgniteSceneTerrainCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public IgniteSceneTerrainCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(IgniteSceneTerrainCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.IgniteSceneTerrain(request, request.Token!);
        return result.ToApiResponse(x => x, "Error lighting the oil");
    }
}
