using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.AddSceneToken;

public class AddSceneTokenCommandHandler : IRequestHandler<AddSceneTokenCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public AddSceneTokenCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(AddSceneTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.AddSceneToken(request, request.Token!);
        return result.ToApiResponse(x => x, "Error adding the token");
    }
}
