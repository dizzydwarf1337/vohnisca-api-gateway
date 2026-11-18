using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.ResolveItemStack;

// I-03: a stack of a tracked item kept from before instances made into its instances, one a piece.
public class ResolveItemStackCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public Guid OperationId { get; set; }
}
