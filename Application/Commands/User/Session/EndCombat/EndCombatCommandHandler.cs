using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.EndCombat;

public class EndCombatCommandHandler : IRequestHandler<EndCombatCommand, ApiResponse<bool>>
{
    private readonly ISessionRpcClient _client;
    public EndCombatCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(EndCombatCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.EndCombat(request, request.Token!);
        return result.ToApiResponse(x => x, "Error ending the fight");
    }
}
