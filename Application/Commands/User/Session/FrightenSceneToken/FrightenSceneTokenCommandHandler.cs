using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.FrightenSceneToken;

public class FrightenSceneTokenCommandHandler : IRequestHandler<FrightenSceneTokenCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public FrightenSceneTokenCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(FrightenSceneTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.FrightenSceneToken(request, request.Token!);
        return result.ToApiResponse(x => x, "Error frightening the creature");
    }
}
