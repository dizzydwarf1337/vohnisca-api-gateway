using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.UnequipItem;

public class UnequipItemCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
}
