using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.AddSceneTerrain;

public class AddSceneTerrainCommandHandler : IRequestHandler<AddSceneTerrainCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public AddSceneTerrainCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(AddSceneTerrainCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.AddSceneTerrain(request, request.Token!);
        return result.ToApiResponse(x => x, "Error adding the terrain");
    }
}
