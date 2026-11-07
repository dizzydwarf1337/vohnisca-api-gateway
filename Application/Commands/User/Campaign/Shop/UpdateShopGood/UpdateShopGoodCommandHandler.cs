using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Shop.UpdateShopGood;

public class UpdateShopGoodCommandHandler : IRequestHandler<UpdateShopGoodCommand, ApiResponse<ShopGoodData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public UpdateShopGoodCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ShopGoodData>> Handle(UpdateShopGoodCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.UpdateShopGood(
            request.GoodId, request.PriceCoins, request.SellPriceCoins, request.Stock,
            request.IsBuyable, request.IsSellable, request.Order, request.Token);
        return result.ToApiResponse(x => x.ShopGood, "Error updating shop good");
    }
}