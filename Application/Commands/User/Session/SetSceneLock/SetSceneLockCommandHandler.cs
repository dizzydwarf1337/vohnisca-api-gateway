using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetSceneLock;

public class SetSceneLockCommandHandler : IRequestHandler<SetSceneLockCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SetSceneLockCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SetSceneLockCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetSceneLock(request, request.Token!);
        return result.ToApiResponse(x => x, "Error setting the lock");
    }
}
