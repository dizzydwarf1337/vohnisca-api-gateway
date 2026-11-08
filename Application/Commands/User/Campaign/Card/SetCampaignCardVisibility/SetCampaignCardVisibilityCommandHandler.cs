using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.SetCampaignCardVisibility;

public class SetCampaignCardVisibilityCommandHandler : IRequestHandler<SetCampaignCardVisibilityCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetCampaignCardVisibilityCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(SetCampaignCardVisibilityCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetCampaignCardVisibility(request.CardId, request.IsPublic, request.Token);
        return result.ToApiResponse(x => x.Card, "Error setting campaign card visibility");
    }
}