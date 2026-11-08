using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Shop.AddShopGood;

// A good is a workshop type put on the shelf with a price. Stock left empty means "as many as anybody wants".
// The sell price is the master's call; the campaign service does not derive it on the client.
public class AddShopGoodCommand : UserRequest<ShopGoodData>
{
    public Guid CardId { get; set; }
    public Guid RefId { get; set; }
    public int PriceCoins { get; set; }
    public int? SellPriceCoins { get; set; }
    public int? Stock { get; set; }
    public bool IsBuyable { get; set; } = true;
    public bool IsSellable { get; set; } = true;
}