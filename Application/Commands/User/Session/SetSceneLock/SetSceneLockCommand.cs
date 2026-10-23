using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetSceneLock;

// The GM locks a door or a container (TargetId: either); Lock null: no lock at all.
public class SetSceneLockCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TargetId { get; set; }
    public LockSettingsData? Lock { get; set; }
}
