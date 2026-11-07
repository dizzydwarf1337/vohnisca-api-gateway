using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.CreateItemCard;

// An instance of a workshop item type: refId points at the type, the card carries what this instance
// means in the campaign (how many, in which container, what the players know).
public class CreateItemCardCommand : UserRequest<CampaignCardData>
{
    public Guid CampaignId { get; set; }
    public Guid? ChapterId { get; set; }
    public Guid RefId { get; set; }
    public int Quantity { get; set; } = 1;
    public Guid? ContainerId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? ContentFormat { get; set; }
}