using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetSessionReady;

// A player who joined marks themselves ready (or not).
public class SetSessionReadyCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public bool Ready { get; set; }
}
