using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.TriggerReady;

public class TriggerReadyCommandHandler : IRequestHandler<TriggerReadyCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public TriggerReadyCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(TriggerReadyCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.TriggerReady(request, request.Token!);
        return result.ToApiResponse(x => x, "Error: TriggerReady");
    }
}
