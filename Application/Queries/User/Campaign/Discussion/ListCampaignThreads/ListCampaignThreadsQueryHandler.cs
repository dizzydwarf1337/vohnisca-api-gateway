using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Discussion.ListCampaignThreads;

public class ListCampaignThreadsQueryHandler : IRequestHandler<ListCampaignThreadsQuery, ApiResponse<List<ThreadData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListCampaignThreadsQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<ThreadData>>> Handle(ListCampaignThreadsQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListCampaignThreads(
            request.CampaignId, request.ChapterId, request.Page, request.PageSize, request.Token);
        return result.ToApiResponse(x => x.Items, "Error listing threads");
    }
}