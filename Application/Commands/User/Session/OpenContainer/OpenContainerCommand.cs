using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.OpenContainer;

// A character looks inside a container within 5 ft.
public class OpenContainerCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid TokenId { get; set; }
}
