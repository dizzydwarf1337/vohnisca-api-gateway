using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Shop.CreateShopCard;

// A shop is a card of kind "shop": its kind settings (isOpen, requiresApproval, markupPercent) live in meta
// and are set with UpdateShopCard.
public class CreateShopCardCommand : UserRequest<CampaignCardData>
{
    public Guid CampaignId { get; set; }
    public Guid? ChapterId { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
    public string? ContentFormat { get; set; }
}