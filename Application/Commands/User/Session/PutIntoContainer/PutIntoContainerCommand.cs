using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.PutIntoContainer;

// A character puts an item from its inventory into a container.
public class PutIntoContainerCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid TokenId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; } = 1;
}
