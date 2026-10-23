using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.RemoveSceneTerrain;

// The GM clears terrain from the map.
public class RemoveSceneTerrainCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TerrainId { get; set; }
}
