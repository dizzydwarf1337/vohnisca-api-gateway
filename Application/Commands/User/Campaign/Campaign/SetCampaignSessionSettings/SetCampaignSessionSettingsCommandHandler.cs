using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.SetCampaignSessionSettings;

public class SetCampaignSessionSettingsCommandHandler : IRequestHandler<SetCampaignSessionSettingsCommand, ApiResponse<CampaignData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetCampaignSessionSettingsCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignData>> Handle(SetCampaignSessionSettingsCommand request, CancellationToken cancellationToken)
        => (await _campaignRpcClient.SetCampaignSessionSettings(request.CampaignId, request.CarryingAffectsMovement, request.Token))
            .ToApiResponse(x => x.Campaign, "Error setting the campaign's session settings");
}
