using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetWallPiece;

public class SetWallPieceCommandHandler : IRequestHandler<SetWallPieceCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SetWallPieceCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SetWallPieceCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetWallPiece(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing the wall");
    }
}
