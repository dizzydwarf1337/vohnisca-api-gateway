using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.DestroyItem;

// I-03: a tracked item the character carries destroyed — an explicit act; whoever was attuned to it no more.
// OperationId: the client's id for this request (the same again is the same act).
public class DestroyItemCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid InstanceId { get; set; }
    public Guid OperationId { get; set; }
}
