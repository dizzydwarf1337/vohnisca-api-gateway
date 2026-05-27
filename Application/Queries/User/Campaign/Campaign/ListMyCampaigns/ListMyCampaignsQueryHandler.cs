using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Campaign.ListMyCampaigns;

public class ListMyCampaignsQueryHandler : IRequestHandler<ListMyCampaignsQuery, ApiResponse<List<CampaignData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListMyCampaignsQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<CampaignData>>> Handle(ListMyCampaignsQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListMyCampaigns(request.UserId!.Value.ToString());
        return result.ToApiResponse(x => x.Campaigns, "Error listing campaigns");
    }
}