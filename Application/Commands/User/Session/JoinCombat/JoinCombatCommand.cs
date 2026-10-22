using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.JoinCombat;

// More tokens join the fight (they roll initiative).
public class JoinCombatCommand : UserRequest<SessionEncounterData>
{
    public Guid SessionId { get; set; }
    public List<Guid> TokenIds { get; set; } = new();
}
