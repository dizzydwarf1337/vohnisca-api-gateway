using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetWallPiece;

// A breakable wall shown to the players or hidden (Hidden), or mended (Mend).
public class SetWallPieceCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid PieceId { get; set; }
    public bool? Hidden { get; set; }
    public bool Mend { get; set; }
}
