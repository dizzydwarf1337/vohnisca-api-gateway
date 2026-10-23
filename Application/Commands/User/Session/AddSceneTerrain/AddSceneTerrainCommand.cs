using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.AddSceneTerrain;

// The GM paints terrain on the map: its squares ([col, row]) and what it does; Hidden: a trap.
public class AddSceneTerrainCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public List<int[]> Cells { get; set; } = [];
    public ZoneEffectData Effect { get; set; } = new();
    public bool Hidden { get; set; }
    // "water" | "ice" | "brush" | "oil": what it does comes with it (the effect is set for it).
    public string? Material { get; set; }
}
