using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetHeroicInspiration;

// F-12: the GM gives a character Heroic Inspiration (Has) or takes it away; given one too many, it is spare.
public class SetHeroicInspirationCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public bool Has { get; set; }
}
