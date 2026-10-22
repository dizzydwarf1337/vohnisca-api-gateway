using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.RemoveSceneToken;

// The GM removes a token.
public class RemoveSceneTokenCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
}
