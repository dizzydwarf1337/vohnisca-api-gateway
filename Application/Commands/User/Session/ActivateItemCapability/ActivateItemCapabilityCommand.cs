using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.ActivateItemCapability;

// I-09: an item's activated capability used at the table (session-service checks and plays it).
public class ActivateItemCapabilityCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    // The inventory row: an instance's id, or the item's for a stack.
    public Guid ItemId { get; set; }
    public Guid CapabilityId { get; set; }
    // Charges to spend (null: the fewest it takes).
    public int? Charges { get; set; }
    // On whom (none: the character itself) — or, for a spell it casts, what the spell is aimed at.
    public List<Guid> TargetTokenIds { get; set; } = [];
    // "normal" | "advantage" | "disadvantage" (a spell attack).
    public string Mode { get; set; } = "normal";
    public string? DamageType { get; set; }
    public string? Choice { get; set; }
    public double? AimCol { get; set; }
    public double? AimRow { get; set; }
    // The player agrees the GM plays the part the table doesn't (refused without it, nothing spent).
    public bool ConfirmManual { get; set; }
    // A Sorcerer's Metamagic on a spell it casts: "quickened", "distant", "careful"...
    public List<string>? Metamagic { get; set; }
}
