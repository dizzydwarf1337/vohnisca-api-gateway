using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.LoadMapLevel;

public class LoadMapLevelCommandHandler : IRequestHandler<LoadMapLevelCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public LoadMapLevelCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(LoadMapLevelCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.LoadMapLevel(request, request.Token!);
        return result.ToApiResponse(x => x, "Error loading the map level");
    }
}
