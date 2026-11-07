using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Card.ListItemCards;

public class ListItemCardsQueryHandler : IRequestHandler<ListItemCardsQuery, ApiResponse<List<CampaignCardData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListItemCardsQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<CampaignCardData>>> Handle(ListItemCardsQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListItemCards(
            request.CampaignId, request.ChapterId, request.ContainerId, request.Page, request.PageSize, request.Token);
        return result.ToApiResponse(x => x.Items, "Error listing item cards");
    }
}