using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Session.GetSessionDashboard;

public class GetSessionDashboardQueryHandler : IRequestHandler<GetSessionDashboardQuery, ApiResponse<SessionDashboardData>>
{
    private readonly ISessionRpcClient _client;
    public GetSessionDashboardQueryHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionDashboardData>> Handle(GetSessionDashboardQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetSessionDashboard(request, request.Token!);
        return result.ToApiResponse(x => x, "Error loading the dashboard");
    }
}
