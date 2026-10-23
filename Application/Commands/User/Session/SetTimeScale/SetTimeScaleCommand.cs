using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetTimeScale;

// How fast the game time runs out of a fight: 0 (stopped) to 60 times the real time.
public class SetTimeScaleCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public double Scale { get; set; } = 1;
}
