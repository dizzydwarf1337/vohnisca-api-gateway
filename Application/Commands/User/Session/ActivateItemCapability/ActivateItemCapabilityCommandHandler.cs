using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.ActivateItemCapability;

public class ActivateItemCapabilityCommandHandler : IRequestHandler<ActivateItemCapabilityCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public ActivateItemCapabilityCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(ActivateItemCapabilityCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ActivateItemCapability(request, request.Token!);
        return result.ToApiResponse(x => x, "Error using the item");
    }
}
