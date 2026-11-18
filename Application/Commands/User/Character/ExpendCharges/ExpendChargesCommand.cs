using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.ExpendCharges;

// I-08: charges spent from a magic item the character carries, out of a session (its effect is the GM's to play).
// Use: the property named (its cost); OperationId: the client's id for this request (the same again is the same spend).
public class ExpendChargesCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid InstanceId { get; set; }
    public int Count { get; set; } = 1;
    public string? Use { get; set; }
    public Guid OperationId { get; set; }
}
