using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.TakeCombatAction;

public class TakeCombatActionCommandHandler : IRequestHandler<TakeCombatActionCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public TakeCombatActionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(TakeCombatActionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.TakeCombatAction(request, request.Token!);
        return result.ToApiResponse(x => x, "Error taking the action");
    }
}
