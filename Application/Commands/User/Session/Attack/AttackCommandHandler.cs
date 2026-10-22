using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.Attack;

public class AttackCommandHandler : IRequestHandler<AttackCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public AttackCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(AttackCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.Attack(request, request.Token!);
        return result.ToApiResponse(x => x, "Error making the attack");
    }
}
