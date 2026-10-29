using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetSessionJoinable;

// The GM opens the session to players joining (the campaign is told), or closes it.
public class SetSessionJoinableCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public bool Joinable { get; set; }
}
