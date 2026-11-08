using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.SetItemPickable;

// Who the game master leaves an item open to. An empty list closes the pick for everybody.
public class SetItemPickableCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public List<Guid> UserIds { get; set; } = [];
}
