using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.LevelUpCharacter;

public class LevelUpCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ClassId { get; set; }
    public int By { get; set; } = 1;
    // Refused by character-service when sent: the server works out a level's hit points (P-07).
    public List<int>? RolledHitPoints { get; set; }
    // One per level-up the client makes: sent again (a lost answer), it changes nothing.
    public Guid? OperationId { get; set; }

    // Level-up choices, keyed like the level-up options.
    public Dictionary<string, List<string>> Choices { get; set; } = new();
}
