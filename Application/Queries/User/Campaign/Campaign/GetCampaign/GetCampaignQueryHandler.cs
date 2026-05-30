using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Campaign.GetCampaign;

public class GetCampaignQueryHandler : IRequestHandler<GetCampaignQuery, ApiResponse<CampaignData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GetCampaignQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignData>> Handle(GetCampaignQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GetCampaign(request.CampaignId, request.Token);
        return result.ToApiResponse(x => x.Campaign, "Error getting campaign");
    }
}