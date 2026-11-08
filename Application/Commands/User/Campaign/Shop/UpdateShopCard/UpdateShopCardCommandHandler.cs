using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Shop.UpdateShopCard;

public class UpdateShopCardCommandHandler : IRequestHandler<UpdateShopCardCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public UpdateShopCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(UpdateShopCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.UpdateShopCard(
            request.CardId, request.Title, request.Content, request.ContentFormat, request.Meta, request.Token);
        return result.ToApiResponse(x => x.Card, "Error updating shop card");
    }
}