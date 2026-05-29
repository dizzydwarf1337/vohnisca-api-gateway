using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Campaign.ListMyCampaigns;

public class ListMyCampaignsQueryHandler : IRequestHandler<ListMyCampaignsQuery, ApiResponse<PaginationResponse<CampaignData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListMyCampaignsQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<PaginationResponse<CampaignData>>> Handle(ListMyCampaignsQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListMyCampaigns(
            request.Pagination,
            request.Sorting,
            request.Filters,
            request.Token!);
        return result.ToApiResponse(x => x, "Error listing campaigns");
    }
}
