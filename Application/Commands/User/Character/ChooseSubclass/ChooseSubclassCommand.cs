using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.ChooseSubclass;

public class ChooseSubclassCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ClassId { get; set; }
    public Guid SubClassId { get; set; }
}
