using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.MoveSceneToken;

public class MoveSceneTokenCommandHandler : IRequestHandler<MoveSceneTokenCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public MoveSceneTokenCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(MoveSceneTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.MoveSceneToken(request, request.Token!);
        return result.ToApiResponse(x => x, "Error moving the token");
    }
}
