using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.UpdateSceneTerrain;

// The GM changes terrain (what's null stays as it is).
public class UpdateSceneTerrainCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TerrainId { get; set; }
    public string? Name { get; set; }
    public string? Color { get; set; }
    public List<int[]>? Cells { get; set; }
    public ZoneEffectData? Effect { get; set; }
    public bool? Hidden { get; set; }
}
