using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.SetCharacterAbilityScores;

public class SetCharacterAbilityScoresCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    // standardArray | pointBuy | rolled; AbilityScores are the new base scores.
    public string Method { get; set; } = string.Empty;
    public Dictionary<string, int> AbilityScores { get; set; } = new();
}
