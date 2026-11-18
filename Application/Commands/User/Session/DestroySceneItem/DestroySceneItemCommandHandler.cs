using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.DestroySceneItem;

public class DestroySceneItemCommandHandler : IRequestHandler<DestroySceneItemCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public DestroySceneItemCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(DestroySceneItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.DestroySceneItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error destroying the item");
    }
}
