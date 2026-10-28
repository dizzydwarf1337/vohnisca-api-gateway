using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.LoadMapLevel;

// The GM plays a level of a workshop map: it becomes the scene.
public class LoadMapLevelCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid MapId { get; set; }
    public Guid LevelId { get; set; }
}
