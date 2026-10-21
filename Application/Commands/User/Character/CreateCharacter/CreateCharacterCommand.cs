using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Character.CreateCharacter;

// A level 1 character (SRD 5.2): identity, picked class/background/species, base ability
// scores and the creation choices. Enum-typed fields are sent as their string names.
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

    // standardArray | pointBuy | rolled — the service validates the base scores against it.
    public string AbilityScoreMethod { get; set; } = "pointBuy";
    public Dictionary<string, int> BaseAbilityScores { get; set; } = new();

    // Level 1 creation choices keyed as the creation-options endpoint describes them.
    public Dictionary<string, List<string>> Choices { get; set; } = new();
}
