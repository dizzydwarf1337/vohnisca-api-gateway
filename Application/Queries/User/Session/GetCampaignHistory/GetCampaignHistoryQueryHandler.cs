using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Session.GetCampaignHistory;

public class GetCampaignHistoryQueryHandler : IRequestHandler<GetCampaignHistoryQuery, ApiResponse<CampaignHistoryData>>
{
    private readonly ISessionRpcClient _client;
    public GetCampaignHistoryQueryHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CampaignHistoryData>> Handle(GetCampaignHistoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetCampaignHistory(request, request.Token!);
        return result.ToApiResponse(x => x, "Error getting the campaign's sessions");
    }
}
