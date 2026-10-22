using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.RollCheck;

// A character's roll with the modifiers from its sheet.
public class RollCheckCommand : UserRequest<DiceRollData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    // "ability:Strength", "save:Dexterity", "skill:Perception", "initiative", "deathSave",
    // "hitDie:D8", "concentration" (the last three apply their result).
    public string Check { get; set; } = string.Empty;
    // "normal" | "advantage" | "disadvantage".
    public string Mode { get; set; } = "normal";
    public bool Secret { get; set; }
}
