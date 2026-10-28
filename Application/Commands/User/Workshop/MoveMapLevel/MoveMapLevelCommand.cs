using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.MoveMapLevel;

public class MoveMapLevelCommand : UserRequest<bool>
{
    public Guid MapId { get; set; }
    public Guid LevelId { get; set; }
    // Its place in the order (0: first).
    public int Index { get; set; }
}
