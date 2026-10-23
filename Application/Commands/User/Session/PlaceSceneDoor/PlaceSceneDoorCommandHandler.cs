using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.PlaceSceneDoor;

public class PlaceSceneDoorCommandHandler : IRequestHandler<PlaceSceneDoorCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public PlaceSceneDoorCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(PlaceSceneDoorCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.PlaceSceneDoor(request, request.Token!);
        return result.ToApiResponse(x => x, "Error placing the door");
    }
}
