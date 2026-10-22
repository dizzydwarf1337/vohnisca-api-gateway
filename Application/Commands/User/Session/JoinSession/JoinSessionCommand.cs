using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.JoinSession;

// A player joins the session with a character (or switches to another one).
public class JoinSessionCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
}
