using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetShortRest;

// The GM starts the party's short rest (Hit Point Dice may be spent) or ends it.
public class SetShortRestCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public bool Resting { get; set; }
    // The rest stopped short (a fight, a spell, damage): no benefit, and no attunement focused in it takes (I-03).
    public bool Interrupted { get; set; }
}
