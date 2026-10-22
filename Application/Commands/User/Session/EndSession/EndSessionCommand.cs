using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.EndSession;

// The GM ends the session (or cancels it from the lobby), keeping or dropping the state of play.
public class EndSessionCommand : UserRequest<bool>
{
    public Guid SessionId { get; set; }
    public bool KeepGameState { get; set; }
}
