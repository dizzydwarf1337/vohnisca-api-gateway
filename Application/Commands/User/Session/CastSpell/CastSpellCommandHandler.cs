using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.CastSpell;

public class CastSpellCommandHandler : IRequestHandler<CastSpellCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public CastSpellCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(CastSpellCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.CastSpell(request, request.Token!);
        return result.ToApiResponse(x => x, "Error casting the spell");
    }
}
