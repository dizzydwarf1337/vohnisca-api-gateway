using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SaveSceneToMap;

// The GM saves the scene into a level of their workshop map (LevelId: that level again; none: a new one named Name).
public class SaveSceneToMapCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid MapId { get; set; }
    public Guid? LevelId { get; set; }
    public string? Name { get; set; }
}
