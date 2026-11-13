using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.Influence;

public class InfluenceCommandHandler : IRequestHandler<InfluenceCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public InfluenceCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(InfluenceCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.Influence(request, request.Token!);
        return result.ToApiResponse(x => x, "Error: Influence");
    }
}
