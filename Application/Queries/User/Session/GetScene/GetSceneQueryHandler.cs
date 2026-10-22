using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Session.GetScene;

public class GetSceneQueryHandler : IRequestHandler<GetSceneQuery, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public GetSceneQueryHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(GetSceneQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetScene(request, request.Token!);
        return result.ToApiResponse(x => x, "Error getting the scene");
    }
}
