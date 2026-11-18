using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Clock.GetCampaignClock;

public class GetCampaignClockQueryHandler : IRequestHandler<GetCampaignClockQuery, ApiResponse<CampaignClockData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GetCampaignClockQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignClockData>> Handle(GetCampaignClockQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GetCampaignClock(request.CampaignId, request.Token);
        return result.ToApiResponse(x => x.Clock, "Error getting campaign clock");
    }
}
