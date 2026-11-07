using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Shop.ApprovePurchase;

// A shop that needs approval holds a purchase until the master decides; approving lets the purchase go on to
// character-service (money and item in one transaction there).
public class ApprovePurchaseCommand : UserRequest<ShopPurchaseData>
{
    public Guid PurchaseId { get; set; }
}