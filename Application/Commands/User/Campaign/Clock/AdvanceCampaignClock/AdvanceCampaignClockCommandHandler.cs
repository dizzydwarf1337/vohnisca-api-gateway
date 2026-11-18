using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Clock.AdvanceCampaignClock;

public class AdvanceCampaignClockCommandHandler : IRequestHandler<AdvanceCampaignClockCommand, ApiResponse<CampaignClockData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public AdvanceCampaignClockCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignClockData>> Handle(AdvanceCampaignClockCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.AdvanceCampaignClock(request.CampaignId, request.Seconds, request.Token);
        return result.ToApiResponse(x => x.Clock, "Error advancing campaign clock");
    }
}
