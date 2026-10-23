using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetSceneWalls;

// The GM draws walls over the background (Wall) or rubs them out: squares as [col, row].
public class SetSceneWallsCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public List<int[]> Cells { get; set; } = [];
    public bool Wall { get; set; }
}
