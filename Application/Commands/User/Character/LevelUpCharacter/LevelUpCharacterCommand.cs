using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.LevelUpCharacter;

public class LevelUpCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ClassId { get; set; }
    public int By { get; set; } = 1;
    public List<int>? RolledHitPoints { get; set; }
}
