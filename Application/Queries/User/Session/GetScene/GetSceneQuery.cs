using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Session.GetScene;

// The session's map as the user may see it.
public class GetSceneQuery : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
}
