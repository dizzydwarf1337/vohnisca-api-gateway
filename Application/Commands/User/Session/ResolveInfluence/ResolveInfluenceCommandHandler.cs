using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.ResolveInfluence;

public class ResolveInfluenceCommandHandler : IRequestHandler<ResolveInfluenceCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public ResolveInfluenceCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(ResolveInfluenceCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ResolveInfluence(request, request.Token!);
        return result.ToApiResponse(x => x, "Error: ResolveInfluence");
    }
}
