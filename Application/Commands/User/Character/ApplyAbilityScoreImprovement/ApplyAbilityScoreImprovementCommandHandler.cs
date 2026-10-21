using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.ApplyAbilityScoreImprovement;

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
