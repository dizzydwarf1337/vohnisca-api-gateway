using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.UnequipSessionItem;

public class UnequipSessionItemCommandHandler : IRequestHandler<UnequipSessionItemCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public UnequipSessionItemCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(UnequipSessionItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UnequipSessionItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error unequipping the item");
    }
}
