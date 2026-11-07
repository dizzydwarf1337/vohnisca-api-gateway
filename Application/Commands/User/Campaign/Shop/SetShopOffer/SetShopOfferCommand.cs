using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Shop.SetShopOffer;

// The master names a price for one player: the shop prices by it when this player buys, the base price
// otherwise. The client never recalculates prices itself.
public class SetShopOfferCommand : UserRequest<ShopGoodData>
{
    public Guid GoodId { get; set; }
    public Guid TargetUserId { get; set; }
    public int PriceCoins { get; set; }
}