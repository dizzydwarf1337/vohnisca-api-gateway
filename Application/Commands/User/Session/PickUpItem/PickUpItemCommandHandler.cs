using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.PickUpItem;

public class PickUpItemCommandHandler : IRequestHandler<PickUpItemCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public PickUpItemCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(PickUpItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.PickUpItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error picking up the item");
    }
}
