using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetCarryingAffectsMovement;

// I-12: the GM lets what the characters carry bear on their Speed, or not (Carrying Capacity Affects Movement).
public class SetCarryingAffectsMovementCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public bool On { get; set; }
}
