using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.FrightenSceneToken;

// F-06: the GM frightens a creature by hand — of a creature on the map (SourceTokenId) or of no one known.
public class FrightenSceneTokenCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public Guid? SourceTokenId { get; set; }
}
