using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.TakeLongRest;

// The GM gives the party a long rest.
public class TakeLongRestCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
}
