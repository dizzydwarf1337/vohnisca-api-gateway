using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.UnprepareSpell;

public class UnprepareSpellCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid SpellId { get; set; }
}
