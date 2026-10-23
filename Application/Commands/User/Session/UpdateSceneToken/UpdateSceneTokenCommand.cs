using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.UpdateSceneToken;

// The GM renames, resizes, hides or shows a token, or sets an NPC's numbers.
public class UpdateSceneTokenCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public string? Name { get; set; }
    public int? Size { get; set; }
    public int? Quantity { get; set; }
    public bool? Hidden { get; set; }
    // An NPC's numbers in play.
    public int? MaxHp { get; set; }
    public int? Hp { get; set; }
    public int? Ac { get; set; }
    public int? Speed { get; set; }
    public int? InitiativeBonus { get; set; }
    // An NPC's side ("" back to hostile; null: as it is).
    public string? Team { get; set; }
    // Saving throw bonuses by ability ("dexterity": 2); the NPC's conditions ("prone"...).
    public Dictionary<string, int>? Saves { get; set; }
    public List<string>? Conditions { get; set; }
    // Damage types ("fire"...) it resists, ignores, takes double; conditions it can't have.
    public List<string>? Resistances { get; set; }
    public List<string>? Immunities { get; set; }
    public List<string>? Vulnerabilities { get; set; }
    public List<string>? ConditionImmunities { get; set; }
    // What lasts on it, by name (the GM's buffs and debuffs; spells keep where they came from).
    public List<string>? Effects { get; set; }
    // Players may look at its sheet.
    public bool? SheetShown { get; set; }
    // All of an NPC's attacks (replacing the ones it had).
    public List<CustomAttackData>? Attacks { get; set; }
    // How many of them one Attack action makes (Multiattack), 1 to 10.
    public int? AttacksPerAction { get; set; }
    // At 0 Hit Points it makes death saves (else it dies, as most monsters do).
    public bool? DeathSaves { get; set; }
}
