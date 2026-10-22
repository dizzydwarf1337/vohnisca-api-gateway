using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Session.GetSession;

public class GetSessionQueryHandler : IRequestHandler<GetSessionQuery, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public GetSessionQueryHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(GetSessionQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetSession(request, request.Token!);
        return result.ToApiResponse(x => x, "Error getting the session");
    }
}
