using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.History.ListCampaignHistory;

public class ListCampaignHistoryQueryHandler : IRequestHandler<ListCampaignHistoryQuery, ApiResponse<List<HistoryEntryData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListCampaignHistoryQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<HistoryEntryData>>> Handle(ListCampaignHistoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListCampaignHistory(
            request.CampaignId, request.Kind, request.ActorId, request.From, request.To,
            request.Page, request.PageSize, request.Token);
        return result.ToApiResponse(x => x.Items, "Error listing campaign history");
    }
}