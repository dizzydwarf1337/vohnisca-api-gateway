using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.MoveSceneToken;

// Moves a token (the GM any, a player their own character). The client moves over the hub; this is the plain request.
public class MoveSceneTokenCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public int Col { get; set; }
    public int Row { get; set; }
}
