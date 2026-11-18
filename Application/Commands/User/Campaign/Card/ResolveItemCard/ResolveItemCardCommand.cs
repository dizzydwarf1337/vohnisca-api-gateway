using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.ResolveItemCard;

// I-03: the GM makes a card of a tracked item kept from before instances into its instances (one card each);
// a card a character holds names the instance from the character's sheet.
public class ResolveItemCardCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public Guid? InstanceId { get; set; }
}
