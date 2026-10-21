using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.ApplyAbilityScoreImprovement;

public class ApplyAbilityScoreImprovementCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ClassId { get; set; }
    public int Level { get; set; }
    public bool IsFeat { get; set; }
    public Guid? FeatId { get; set; }
    public Dictionary<string, int>? AbilityIncreases { get; set; }
    public string? HalfFeatAbility { get; set; }
}
