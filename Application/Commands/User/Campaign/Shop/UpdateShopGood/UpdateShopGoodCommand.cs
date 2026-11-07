using System.Text.Json;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Shop.UpdateShopGood;

// A patch of a good. Only the keys the caller sends go to the campaign service — except stock, which is raw
// JSON because the service tells an absent key ("leave it as it is") from an explicit null ("no limit"),
// and a plain int? cannot carry that difference.
public class UpdateShopGoodCommand : UserRequest<ShopGoodData>
{
    public Guid GoodId { get; set; }
    public int? PriceCoins { get; set; }
    public int? SellPriceCoins { get; set; }
    public JsonElement Stock { get; set; }
    public bool? IsBuyable { get; set; }
    public bool? IsSellable { get; set; }
    public int? Order { get; set; }
}