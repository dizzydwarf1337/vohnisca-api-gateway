using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Shop.BuyFromShop;

// A purchase: the campaign service checks the shop, the good, the stock and the price (the buyer's own offer
// first), reserves the stock and asks character-service for the money and the item over the bus. The price is
// never taken from the client.
public class BuyFromShopCommand : UserRequest<ShopPurchaseData>
{
    public Guid CardId { get; set; }
    public Guid GoodId { get; set; }
    public int Quantity { get; set; } = 1;
    public Guid CharacterId { get; set; }
}