using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.LeaveSession;

// A player leaves the lobby; their character is given back.
public class LeaveSessionCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
}
