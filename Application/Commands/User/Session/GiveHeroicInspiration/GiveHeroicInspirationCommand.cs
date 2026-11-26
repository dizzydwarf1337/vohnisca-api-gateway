using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.GiveHeroicInspiration;

// F-12: a character's spare Heroic Inspiration goes To a party member without one; To null: it is let go.
public class GiveHeroicInspirationCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid? To { get; set; }
}
