using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.DestroyItemCard;

// I-03: the GM destroys a tracked item lying in a card — an explicit act; the card shows it once the
// character service confirms.
public class DestroyItemCardCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
}
