using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Shop.BuyFromShop;

public class BuyFromShopCommandHandler : IRequestHandler<BuyFromShopCommand, ApiResponse<ShopPurchaseData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public BuyFromShopCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ShopPurchaseData>> Handle(BuyFromShopCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.BuyFromShop(
            request.CardId, request.GoodId, request.Quantity, request.CharacterId, request.Token);
        return result.ToApiResponse(x => x.ShopPurchase, "Error buying from shop");
    }
}