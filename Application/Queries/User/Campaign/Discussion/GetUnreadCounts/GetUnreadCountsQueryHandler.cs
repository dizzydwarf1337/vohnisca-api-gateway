using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Discussion.GetUnreadCounts;

public class GetUnreadCountsQueryHandler : IRequestHandler<GetUnreadCountsQuery, ApiResponse<UnreadCountsResponse>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GetUnreadCountsQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<UnreadCountsResponse>> Handle(GetUnreadCountsQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GetUnreadCounts(request.CampaignId, request.Token);
        return result.ToApiResponse(x => x, "Error getting unread counts");
    }
}