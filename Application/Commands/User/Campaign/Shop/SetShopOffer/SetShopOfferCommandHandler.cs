using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Shop.SetShopOffer;

public class SetShopOfferCommandHandler : IRequestHandler<SetShopOfferCommand, ApiResponse<ShopGoodData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetShopOfferCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ShopGoodData>> Handle(SetShopOfferCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetShopOffer(request.GoodId, request.TargetUserId, request.PriceCoins, request.Token);
        return result.ToApiResponse(x => x.ShopGood, "Error setting shop offer");
    }
}