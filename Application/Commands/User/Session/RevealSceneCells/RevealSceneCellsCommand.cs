using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.RevealSceneCells;

// The GM reveals cells to the players (or covers them again).
public class RevealSceneCellsCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    // [col, row] pairs.
    public List<int[]> Cells { get; set; } = new();
    public bool Reveal { get; set; }
}
