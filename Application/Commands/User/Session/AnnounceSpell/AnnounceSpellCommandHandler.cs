using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.AnnounceSpell;

public class AnnounceSpellCommandHandler : IRequestHandler<AnnounceSpellCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public AnnounceSpellCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(AnnounceSpellCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.AnnounceSpell(request, request.Token!);
        return result.ToApiResponse(x => x, "Error announcing the spell");
    }
}
