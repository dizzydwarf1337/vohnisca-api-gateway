using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.ReadySpell;

public class ReadySpellCommandHandler : IRequestHandler<ReadySpellCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public ReadySpellCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(ReadySpellCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ReadySpell(request, request.Token!);
        return result.ToApiResponse(x => x, "Error: ReadySpell");
    }
}
