using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.CastSpell;

// A character casts a spell at tokens on the map; the dice roll on the server and the
// log tells what happened.
public class CastSpellCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid SpellId { get; set; }
    // For a leveled spell (none for a ritual or a free cast).
    public int? SlotLevel { get; set; }
    public bool AsRitual { get; set; }
    // A token once per dart, ray or beam it takes (once otherwise).
    public List<Guid> TargetTokenIds { get; set; } = [];
    // "normal" | "advantage" | "disadvantage" (a spell attack).
    public string Mode { get; set; } = "normal";
    // The caster's pick when the spell lets them choose ("fire", "cold"...).
    public string? DamageType { get; set; }
    // What a buff asks its caster to pick (Resistance: a damage type; Guidance: a skill).
    public string? Choice { get; set; }
    // Where an area spell is placed or pointed, in cells: its targets are whoever is in it.
    public double? AimCol { get; set; }
    public double? AimRow { get; set; }
    // The creatures a spell that lets its caster pick leaves alone (the party when none).
    public List<Guid>? SparedTokenIds { get; set; }
}
