using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Session.GetSession;

// A session the user's campaign is playing.
public class GetSessionQuery : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
}
