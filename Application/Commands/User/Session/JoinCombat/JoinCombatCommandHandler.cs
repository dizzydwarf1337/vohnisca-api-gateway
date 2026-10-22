using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.JoinCombat;

public class JoinCombatCommandHandler : IRequestHandler<JoinCombatCommand, ApiResponse<SessionEncounterData>>
{
    private readonly ISessionRpcClient _client;
    public JoinCombatCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionEncounterData>> Handle(JoinCombatCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.JoinCombat(request, request.Token!);
        return result.ToApiResponse(x => x, "Error adding to the fight");
    }
}
