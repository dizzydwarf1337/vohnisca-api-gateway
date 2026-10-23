using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetBreakableWalls;

public class SetBreakableWallsCommandHandler : IRequestHandler<SetBreakableWallsCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SetBreakableWallsCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SetBreakableWallsCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetBreakableWalls(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing the walls");
    }
}
