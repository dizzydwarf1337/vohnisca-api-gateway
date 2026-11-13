using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.ResolveInfluence;

// The GM's answer to an Influence: "willing" | "unwilling" | "hesitant" (the check: DC 15 or the creature's Intelligence).
public class ResolveInfluenceCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid AttemptId { get; set; }
    public string Attitude { get; set; } = string.Empty;
    public int? Intelligence { get; set; }
    public int? Bonus { get; set; }
}
