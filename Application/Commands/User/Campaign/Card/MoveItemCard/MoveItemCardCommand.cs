using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.MoveItemCard;

// Moving an item into a container or out of it (no containerId = out). A container inside a container is
// refused by the campaign service (-32602 → 422), the gateway does not second-guess it.
public class MoveItemCardCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public Guid? ContainerId { get; set; }
}