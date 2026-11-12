using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.EndTurn;

// Ends the current turn (the GM, or the player whose turn it is).
public class EndTurnCommand : UserRequest<SessionEncounterData>
{
    public Guid SessionId { get; set; }

    // The turn being ended, as the client saw it (EncounterData.TurnId). A turn that is over
    // already — the button pressed twice — is answered with 409 and nothing changes.
    public Guid TurnId { get; set; }
}
