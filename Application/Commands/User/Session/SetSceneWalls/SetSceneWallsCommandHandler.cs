using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetSceneWalls;

public class SetSceneWallsCommandHandler : IRequestHandler<SetSceneWallsCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SetSceneWallsCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SetSceneWallsCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetSceneWalls(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing the walls");
    }
}
