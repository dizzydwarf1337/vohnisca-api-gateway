using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Clock.ForceReleaseCampaignClock;

public class ForceReleaseCampaignClockCommandHandler : IRequestHandler<ForceReleaseCampaignClockCommand, ApiResponse<CampaignClockData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ForceReleaseCampaignClockCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignClockData>> Handle(ForceReleaseCampaignClockCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ForceReleaseCampaignClock(request.CampaignId, request.Token);
        return result.ToApiResponse(x => x.Clock, "Error releasing campaign clock");
    }
}
