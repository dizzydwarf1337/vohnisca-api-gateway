using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.AttuneItem;

public class AttuneItemCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public bool Attune { get; set; } = true;
}
