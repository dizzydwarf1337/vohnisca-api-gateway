using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.UpdateCampaignCard;

public class UpdateCampaignCardCommandHandler : IRequestHandler<UpdateCampaignCardCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public UpdateCampaignCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(UpdateCampaignCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.UpdateCampaignCard(
            request.CardId, request.Title, request.Content, request.ContentFormat,
            request.Meta, request.BackgroundColor, request.Order, request.Token);
        return result.ToApiResponse(x => x.Card, "Error updating campaign card");
    }
}