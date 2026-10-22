using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetScene;

public class SetSceneCommandHandler : IRequestHandler<SetSceneCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SetSceneCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SetSceneCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetScene(request, request.Token!);
        return result.ToApiResponse(x => x, "Error setting the scene");
    }
}
