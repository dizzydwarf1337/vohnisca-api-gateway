using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.UnlockLock;

public class UnlockLockCommandHandler : IRequestHandler<UnlockLockCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public UnlockLockCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(UnlockLockCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UnlockLock(request, request.Token!);
        return result.ToApiResponse(x => x, "Error with the lock");
    }
}
