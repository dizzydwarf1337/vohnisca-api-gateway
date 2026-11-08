using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Card.ListCampaignCards;

public class ListCampaignCardsQueryHandler : IRequestHandler<ListCampaignCardsQuery, ApiResponse<List<CampaignCardData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListCampaignCardsQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<CampaignCardData>>> Handle(ListCampaignCardsQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListCampaignCards(request.CampaignId, request.Kind, request.ChapterId, request.AllChapters, request.Page, request.PageSize, request.Token);
        return result.ToApiResponse(x => x.Items, "Error listing campaign cards");
    }
}