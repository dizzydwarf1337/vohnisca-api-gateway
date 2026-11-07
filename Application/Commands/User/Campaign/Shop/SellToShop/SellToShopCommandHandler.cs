using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Shop.SellToShop;

public class SellToShopCommandHandler : IRequestHandler<SellToShopCommand, ApiResponse<ShopPurchaseData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SellToShopCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ShopPurchaseData>> Handle(SellToShopCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SellToShop(request.CardId, request.ItemCardId, request.Token);
        return result.ToApiResponse(x => x.ShopPurchase, "Error selling to shop");
    }
}