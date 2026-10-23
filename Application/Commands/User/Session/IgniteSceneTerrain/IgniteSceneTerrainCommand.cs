using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.IgniteSceneTerrain;

// The GM sets poured oil burning.
public class IgniteSceneTerrainCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TerrainId { get; set; }
}
