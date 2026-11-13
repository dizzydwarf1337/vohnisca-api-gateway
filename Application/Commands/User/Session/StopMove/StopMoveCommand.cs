using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.StopMove;

// The mover gives up the rest of a move that waits on reactions to it (opportunity attacks).
public class StopMoveCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
}
