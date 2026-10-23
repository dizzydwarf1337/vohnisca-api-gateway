using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetTokenLight;

public class SetTokenLightCommandHandler : IRequestHandler<SetTokenLightCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SetTokenLightCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SetTokenLightCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetTokenLight(request, request.Token!);
        return result.ToApiResponse(x => x, "Error with the light");
    }
}
