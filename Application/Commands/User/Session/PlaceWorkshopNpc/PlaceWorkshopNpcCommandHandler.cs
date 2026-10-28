using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.PlaceWorkshopNpc;

public class PlaceWorkshopNpcCommandHandler : IRequestHandler<PlaceWorkshopNpcCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public PlaceWorkshopNpcCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(PlaceWorkshopNpcCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.PlaceWorkshopNpc(request, request.Token!);
        return result.ToApiResponse(x => x, "Error placing the NPC");
    }
}
