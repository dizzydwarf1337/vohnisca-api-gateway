using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.RemoveMapLevel;

public class RemoveMapLevelCommand : UserRequest<bool>
{
    public Guid MapId { get; set; }
    public Guid LevelId { get; set; }
}
