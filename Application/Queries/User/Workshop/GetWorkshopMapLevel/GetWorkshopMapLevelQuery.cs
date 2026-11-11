using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Workshop.GetWorkshopMapLevel;

// One level of a workshop map with its scene (the session's own scene JSON): what the map
// editor opens to change a level.
public class GetWorkshopMapLevelQuery : UserRequest<WorkshopMapLevelScene>
{
    public Guid MapId { get; set; }
    public Guid LevelId { get; set; }
}
