using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Card.ReorderCampaignCards;

// Positions inside one scope: the cards of a chapter (ChapterId set) or the cards of the campaign
// itself (ChapterId empty).
public class ReorderCampaignCardsCommand : UserRequest<Unit>
{
    public Guid CampaignId { get; set; }
    public Guid? ChapterId { get; set; }
    public List<string> OrderedIds { get; set; } = [];
}