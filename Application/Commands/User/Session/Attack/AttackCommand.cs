using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.Attack;

// One token attacks another: the roll against AC, and the damage dealt.
public class AttackCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid AttackerTokenId { get; set; }
    public Guid TargetTokenId { get; set; }
    // One of the attacker's weapons (a character's attacks), or a custom attack (the GM's).
    public string? OptionId { get; set; }
    public CustomAttackData? Custom { get; set; }
    // "normal" | "advantage" | "disadvantage".
    public string Mode { get; set; } = "normal";
    // Off-turn, with the reaction (an opportunity attack).
    public bool Reaction { get; set; }
    // The GM's custom attack is kept on the NPC for the next time.
    public bool Remember { get; set; }
}
