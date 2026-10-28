using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.RenameMapLevel;

public class RenameMapLevelCommand : UserRequest<bool>
{
    public Guid MapId { get; set; }
    public Guid LevelId { get; set; }
    public string Name { get; set; } = string.Empty;
}
