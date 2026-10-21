using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.RemoveItemFromCharacter;

public class RemoveItemFromCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; } = 1;
}
