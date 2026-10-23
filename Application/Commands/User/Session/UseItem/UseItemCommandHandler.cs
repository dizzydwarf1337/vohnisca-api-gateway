using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.UseItem;

public class UseItemCommandHandler : IRequestHandler<UseItemCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public UseItemCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(UseItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UseItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error using the item");
    }
}
