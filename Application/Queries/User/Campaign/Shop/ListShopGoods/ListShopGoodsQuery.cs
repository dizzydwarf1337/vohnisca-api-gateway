using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Shop.ListShopGoods;

// What a shop offers: the workshop types it sells, with the price the server decided for this reader.
public class ListShopGoodsQuery : UserRequest<List<ShopGoodData>>
{
    public Guid CardId { get; set; }
}