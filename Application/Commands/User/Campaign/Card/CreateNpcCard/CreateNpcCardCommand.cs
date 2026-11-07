using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.CreateNpcCard;

// An NPC card points at a workshop entry (refId): the entity lives in the workshop, the campaign keeps
// the card with what the players may know about it.
public class CreateNpcCardCommand : UserRequest<CampaignCardData>
{
    public Guid CampaignId { get; set; }
    public Guid? ChapterId { get; set; }
    public Guid RefId { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
    public string? ContentFormat { get; set; }
}