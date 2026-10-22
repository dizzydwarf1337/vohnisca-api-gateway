using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.RemoveSceneArea;

// The GM clears a spell's area from the map.
public class RemoveSceneAreaCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid AreaId { get; set; }
}
