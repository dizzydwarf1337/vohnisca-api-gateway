using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.UpdateSceneToken;

public class UpdateSceneTokenCommandHandler : IRequestHandler<UpdateSceneTokenCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public UpdateSceneTokenCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(UpdateSceneTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UpdateSceneToken(request, request.Token!);
        return result.ToApiResponse(x => x, "Error updating the token");
    }
}
