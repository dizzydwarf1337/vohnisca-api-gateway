using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Session.ListMySessions;

public class ListMySessionsQueryHandler : IRequestHandler<ListMySessionsQuery, ApiResponse<List<SessionNoticeData>>>
{
    private readonly ISessionRpcClient _client;
    public ListMySessionsQueryHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<List<SessionNoticeData>>> Handle(ListMySessionsQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.ListMySessions(request, request.Token!);
        return result.ToApiResponse(x => x, "Error listing sessions");
    }
}
