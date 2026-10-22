using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetSceneFog;

public class SetSceneFogCommandHandler : IRequestHandler<SetSceneFogCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SetSceneFogCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SetSceneFogCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetSceneFog(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing the fog");
    }
}
