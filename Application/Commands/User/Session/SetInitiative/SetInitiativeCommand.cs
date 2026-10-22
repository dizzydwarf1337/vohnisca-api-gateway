using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetInitiative;

// The GM sets a combatant's initiative.
public class SetInitiativeCommand : UserRequest<SessionEncounterData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public int Initiative { get; set; }
}
