using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.PlaceSceneDoor;

// The GM sets a door on a square (Place) or takes it away.
public class PlaceSceneDoorCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public int Col { get; set; }
    public int Row { get; set; }
    public bool Place { get; set; }
}
