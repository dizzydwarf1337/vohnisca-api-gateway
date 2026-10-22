using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.StartCombat;

public class StartCombatCommandHandler : IRequestHandler<StartCombatCommand, ApiResponse<SessionEncounterData>>
{
    private readonly ISessionRpcClient _client;
    public StartCombatCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionEncounterData>> Handle(StartCombatCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.StartCombat(request, request.Token!);
        return result.ToApiResponse(x => x, "Error starting the fight");
    }
}
