using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

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

public class ApplyAbilityScoreImprovementCommandHandler : IRequestHandler<ApplyAbilityScoreImprovementCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public ApplyAbilityScoreImprovementCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(ApplyAbilityScoreImprovementCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ApplyAbilityScoreImprovement(request, request.Token!);
        return result.ToApiResponse(x => x, "Error applying ability score improvement");
    }
}
