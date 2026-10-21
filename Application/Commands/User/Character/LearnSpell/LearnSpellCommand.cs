using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.LearnSpell;

public class LearnSpellCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid SpellId { get; set; }
}
