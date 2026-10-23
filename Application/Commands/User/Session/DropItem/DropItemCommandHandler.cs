using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.DropItem;

public class DropItemCommandHandler : IRequestHandler<DropItemCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public DropItemCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(DropItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.DropItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error dropping the item");
    }
}
