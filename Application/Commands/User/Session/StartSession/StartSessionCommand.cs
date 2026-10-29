using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.StartSession;

// The GM starts the session: alone too; Anyway — without waiting on who isn't ready.
public class StartSessionCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public bool Anyway { get; set; }
}
