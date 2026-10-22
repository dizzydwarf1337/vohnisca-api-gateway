using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.TakeCombatAction;

// Dodge, Disengage, Help (against an enemy within 5 ft) or Hide, for the action.
public class TakeCombatActionCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    // "dodge" | "disengage" | "help" | "hide".
    public string Action { get; set; } = string.Empty;
    // Help: the enemy helped against.
    public Guid? TargetTokenId { get; set; }
}
