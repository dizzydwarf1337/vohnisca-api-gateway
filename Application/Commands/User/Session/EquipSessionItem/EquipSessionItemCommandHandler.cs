using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.EquipSessionItem;

public class EquipSessionItemCommandHandler : IRequestHandler<EquipSessionItemCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public EquipSessionItemCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(EquipSessionItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.EquipSessionItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error equipping the item");
    }
}
