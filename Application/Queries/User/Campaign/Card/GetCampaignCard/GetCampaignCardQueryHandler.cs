using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Card.GetCampaignCard;

public class GetCampaignCardQueryHandler : IRequestHandler<GetCampaignCardQuery, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GetCampaignCardQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(GetCampaignCardQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GetCampaignCard(request.CardId, request.Token);
        return result.ToApiResponse(x => x.Card, "Error getting campaign card");
    }
}