using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.ReturnItemCardToStash;

// An item a character holds goes back to the stash it came from (I-03: a tracked one as its instance).
// Its holder's player or the campaign's master asks; the campaign service can't see whose character it is.
public class ReturnItemCardToStashCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
}
