using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.RemoveCombatant;

// A token leaves the fight.
public class RemoveCombatantCommand : UserRequest<SessionEncounterData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
}
