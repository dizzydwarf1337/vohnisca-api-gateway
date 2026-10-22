using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.StartSession;

// The GM starts the session once every player is ready.
public class StartSessionCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
}
