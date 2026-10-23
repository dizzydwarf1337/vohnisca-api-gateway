using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.TakeFromContainer;

// A character takes from a container: one kind of item (Quantity of it, all by default) or everything (ItemId null).
public class TakeFromContainerCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid TokenId { get; set; }
    public Guid? ItemId { get; set; }
    public int? Quantity { get; set; }
}
