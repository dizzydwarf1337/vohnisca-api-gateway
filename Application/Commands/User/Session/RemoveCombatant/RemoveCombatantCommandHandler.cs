using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.RemoveCombatant;

public class RemoveCombatantCommandHandler : IRequestHandler<RemoveCombatantCommand, ApiResponse<SessionEncounterData>>
{
    private readonly ISessionRpcClient _client;
    public RemoveCombatantCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionEncounterData>> Handle(RemoveCombatantCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RemoveCombatant(request, request.Token!);
        return result.ToApiResponse(x => x, "Error removing from the fight");
    }
}
