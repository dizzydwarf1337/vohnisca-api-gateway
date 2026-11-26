using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.StartCombat;

// The GM starts a fight with these tokens; initiative is rolled on the server.
public class StartCombatCommand : UserRequest<SessionEncounterData>
{
    public Guid SessionId { get; set; }
    public List<Guid> TokenIds { get; set; } = new();
    // F-14: those of TokenIds the GM marks as surprised by the fight starting (Disadvantage on their initiative).
    public List<Guid>? SurprisedTokenIds { get; set; }
}
