using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.TakeCombatAction;

// Dodge, Disengage, Help (against an enemy within 5 ft), Hide, or a class feature's action.
public class TakeCombatActionCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    // "dodge" | "disengage" | "help" | "hide" | "rage" | ... | "breathWeapon" (the session service's names).
    public string Action { get; set; } = string.Empty;
    // Help: the enemy helped against; Lay On Hands, Divine Spark: who it goes to.
    public Guid? TargetTokenId { get; set; }
    // Breath Weapon: where the cone points, in cells.
    public double? AimCol { get; set; }
    public double? AimRow { get; set; }
}
