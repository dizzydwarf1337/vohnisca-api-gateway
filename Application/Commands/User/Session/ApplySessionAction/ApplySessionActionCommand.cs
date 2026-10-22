using System.Text.Json;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.ApplySessionAction;

// The GM (any character) or a player (their own) acts in play.
public class ApplySessionActionCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    // A character action: { "type": "takeDamage", "amount": 7, "damageType": "Fire" }.
    public JsonElement Action { get; set; }
}
