using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetBreakableWalls;

// The GM makes wall squares ([col, row]) breakable (hidden from the players at first), or plain walls again.
public class SetBreakableWallsCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public List<int[]> Cells { get; set; } = [];
    public bool Breakable { get; set; }
}
