using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.PrepareSpell;

public class PrepareSpellCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid SpellId { get; set; }
}
