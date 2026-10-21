using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.AddClassToCharacter;

public class AddClassToCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ClassId { get; set; }
    public int Level { get; set; } = 1;
    public List<string>? ChosenSkills { get; set; }
    public List<int>? RolledHitPoints { get; set; }
}
