using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.EndCombat;

// The GM ends the fight.
public class EndCombatCommand : UserRequest<bool>
{
    public Guid SessionId { get; set; }
}
