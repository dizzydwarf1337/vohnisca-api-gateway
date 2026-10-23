using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.UnlockLock;

// A character opens a lock on a door or a container: How "key" | "pick" (Thieves' Tools) | "force" (Athletics).
public class UnlockLockCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid TargetId { get; set; }
    public string How { get; set; } = "pick";
}
