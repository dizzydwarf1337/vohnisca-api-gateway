using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SaveSceneToMap;

public class SaveSceneToMapCommandHandler : IRequestHandler<SaveSceneToMapCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SaveSceneToMapCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SaveSceneToMapCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SaveSceneToMap(request, request.Token!);
        return result.ToApiResponse(x => x, "Error saving the scene to the map");
    }
}
