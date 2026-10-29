using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.TakeCombatAction;

// Dodge, Disengage, Help (against an enemy within 5 ft), Hide, or a class feature's action.
public class TakeCombatActionCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    // "dodge" | "disengage" | "help" | "hide" | "stabilize" | "grapple" | "shoveProne" | "shoveAway" | "release" | "rage" | ... | "breathWeapon" (the session service's names).
    public string Action { get; set; } = string.Empty;
    // Help: the enemy helped against; Lay On Hands, Divine Spark, Grapple, Shove: who it goes to.
    public Guid? TargetTokenId { get; set; }
    // Breath Weapon: where the cone points, in cells.
    public double? AimCol { get; set; }
    public double? AimRow { get; set; }
    // Grapple, Shove by an NPC: the GM's DC (its stat block's escape DC).
    public int? Dc { get; set; }
    // Font of Magic: the spell slot's level (into points, or made of them).
    public int? Level { get; set; }
}
