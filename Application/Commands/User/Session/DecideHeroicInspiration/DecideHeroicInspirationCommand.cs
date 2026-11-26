using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.DecideHeroicInspiration;

// F-12: on the roll a held command waits on (HeldId, Step as shown): Reroll one die (Term, Die) with Heroic Inspiration —
// its player only — or keep it (its player or the GM).
public class DecideHeroicInspirationCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid HeldId { get; set; }
    public int Step { get; set; }
    public bool Reroll { get; set; }
    public int Term { get; set; }
    public int Die { get; set; }
}
