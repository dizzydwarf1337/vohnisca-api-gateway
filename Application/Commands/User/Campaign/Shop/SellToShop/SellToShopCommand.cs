using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Shop.SellToShop;

// The mirror flow: the player's item card goes to the shop, the coins go to the character — character-service
// does both in one transaction over the bus, the shop's stock grows.
public class SellToShopCommand : UserRequest<ShopPurchaseData>
{
    public Guid CardId { get; set; }
    public Guid ItemCardId { get; set; }
}