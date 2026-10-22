using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.RemoveSceneArea;

public class RemoveSceneAreaCommandHandler : IRequestHandler<RemoveSceneAreaCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public RemoveSceneAreaCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(RemoveSceneAreaCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RemoveSceneArea(request, request.Token!);
        return result.ToApiResponse(x => x, "Error clearing the area");
    }
}
