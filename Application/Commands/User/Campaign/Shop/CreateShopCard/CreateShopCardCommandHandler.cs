using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Shop.CreateShopCard;

public class CreateShopCardCommandHandler : IRequestHandler<CreateShopCardCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreateShopCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(CreateShopCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.CreateShopCard(
            request.CampaignId, request.ChapterId, request.Title, request.Content, request.ContentFormat, request.Token);
        return result.ToApiResponse(x => x.Card, "Error creating shop card");
    }
}