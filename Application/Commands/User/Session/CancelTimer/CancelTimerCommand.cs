using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.CancelTimer;

// The GM drops a timer (what it would end lasts).
public class CancelTimerCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid TimerId { get; set; }
}
