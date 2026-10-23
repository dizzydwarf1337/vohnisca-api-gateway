using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.UseDoor;

// A door opened or closed by a creature within 5 ft (ActorTokenId), or by the GM from anywhere.
public class UseDoorCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid DoorId { get; set; }
    public Guid? ActorTokenId { get; set; }
}
