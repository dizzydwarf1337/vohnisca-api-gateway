using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Shop.ListShopGoods;

public class ListShopGoodsQueryHandler : IRequestHandler<ListShopGoodsQuery, ApiResponse<List<ShopGoodData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListShopGoodsQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<ShopGoodData>>> Handle(ListShopGoodsQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListShopGoods(request.CardId, request.Token);
        return result.ToApiResponse(x => x.Goods, "Error listing shop goods");
    }
}