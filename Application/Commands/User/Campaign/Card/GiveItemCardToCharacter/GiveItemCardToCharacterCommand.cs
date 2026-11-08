using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.GiveItemCardToCharacter;

// The game master hands an item of the campaign to a character. The item leaves by the same event a stash
// take uses, so the card comes back with a pending transfer and the pick closes for everybody.
public class GiveItemCardToCharacterCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public Guid CharacterId { get; set; }
}
