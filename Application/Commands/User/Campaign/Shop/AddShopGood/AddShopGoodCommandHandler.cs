using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Shop.AddShopGood;

public class AddShopGoodCommandHandler : IRequestHandler<AddShopGoodCommand, ApiResponse<ShopGoodData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public AddShopGoodCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ShopGoodData>> Handle(AddShopGoodCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.AddShopGood(
            request.CardId, request.RefId, request.PriceCoins, request.SellPriceCoins,
            request.Stock, request.IsBuyable, request.IsSellable, request.Token);
        return result.ToApiResponse(x => x.ShopGood, "Error adding shop good");
    }
}