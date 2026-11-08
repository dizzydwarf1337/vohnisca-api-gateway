using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.PickItemCard;

// A player takes the item the game master left open to them, for their own character. The campaign service
// cannot see characters, so the ownership check lives here: the character sheet says how the caller relates
// to the character, and only an owner may pick for it.
public class PickItemCardCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public Guid CharacterId { get; set; }
}
