using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.SaveMapLevel;

// A level saved into one of the user's own maps. The table saves it over the bus, a campaign scene builder
// comes here through the gateway (stage 06) — the workshop does the same save both ways. LevelId null means
// a new level at the end of the map.
public class SaveMapLevelCommand : UserRequest<WorkshopMapLevelSaved>
{
    public Guid MapId { get; set; }
    public Guid? LevelId { get; set; }
    public string Name { get; set; } = string.Empty;
    // The scene JSON of the table, kept as it comes; the grid is the workshop's rule (1..200 each way).
    public string Scene { get; set; } = "{}";
    public int Cols { get; set; }
    public int Rows { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    // What of the workshop's NPCs and items lie on the level, shown without opening the scene.
    public List<Guid>? NpcIds { get; set; }
    public List<Guid>? ItemIds { get; set; }
}