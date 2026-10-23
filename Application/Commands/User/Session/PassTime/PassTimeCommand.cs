using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.PassTime;

// The GM moves the game time on by Seconds (out of a fight).
public class PassTimeCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public double Seconds { get; set; }
}
