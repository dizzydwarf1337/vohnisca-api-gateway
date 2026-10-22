using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.RevealSceneCells;

public class RevealSceneCellsCommandHandler : IRequestHandler<RevealSceneCellsCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public RevealSceneCellsCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(RevealSceneCellsCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RevealSceneCells(request, request.Token!);
        return result.ToApiResponse(x => x, "Error revealing the map");
    }
}
