using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.UnlearnSpell;

public class UnlearnSpellCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid SpellId { get; set; }
}
