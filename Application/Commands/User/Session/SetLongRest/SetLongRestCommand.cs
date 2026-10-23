using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetLongRest;

// The GM starts the party's long rest (prepared spells may change) or ends it (what it restores comes back).
public class SetLongRestCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public bool Resting { get; set; }
}
