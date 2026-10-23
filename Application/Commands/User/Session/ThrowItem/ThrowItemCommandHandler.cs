using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.ThrowItem;

public class ThrowItemCommandHandler : IRequestHandler<ThrowItemCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public ThrowItemCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(ThrowItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ThrowItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error throwing the item");
    }
}
