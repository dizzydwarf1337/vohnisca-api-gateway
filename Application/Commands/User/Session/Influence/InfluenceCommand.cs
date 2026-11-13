using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.Influence;

// Influence: a request to a creature; the GM answers by its attitude (ResolveInfluence).
public class InfluenceCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public Guid TargetTokenId { get; set; }
    public string Skill { get; set; } = string.Empty;
    public string Request { get; set; } = string.Empty;
}
