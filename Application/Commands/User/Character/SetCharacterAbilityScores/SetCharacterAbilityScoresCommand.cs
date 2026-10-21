using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.SetCharacterAbilityScores;

public class SetCharacterAbilityScoresCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Dictionary<string, int> AbilityScores { get; set; } = new();
}
