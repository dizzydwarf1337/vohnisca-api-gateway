using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.EndTurn;

// Ends the current turn (the GM, or the player whose turn it is).
public class EndTurnCommand : UserRequest<SessionEncounterData>
{
    public Guid SessionId { get; set; }
}
