using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Character.CreateCharacter;

// Carries the staged selections from the character creator. Enum-typed fields are sent
// as their (camelCase) string names; the character service parses them back to enums.
public class CreateCharacterCommand : UserRequest<CreateCharacterData>
{
    public string Name { get; set; } = string.Empty;
    public string Alignment { get; set; } = "unaligned";
    public int Age { get; set; }
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }

    public Guid RaceId { get; set; }
    public Guid? SubRaceId { get; set; }
    public Guid BackgroundId { get; set; }
    public Guid ClassId { get; set; }
    public int ClassLevel { get; set; } = 1;

    public Dictionary<string, int> BaseAbilityScores { get; set; } = new();
    public Dictionary<string, int>? CustomAbilityIncreases { get; set; }

    public List<string> ChosenSkills { get; set; } = new();
    public List<string>? ChosenLanguages { get; set; }
    public List<string>? ChosenToolProficiencies { get; set; }

    public List<int> ChosenEquipmentOptions { get; set; } = new();
}
