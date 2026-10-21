using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.SetCharacterAbilityScores;

public class SetCharacterAbilityScoresCommandHandler : IRequestHandler<SetCharacterAbilityScoresCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public SetCharacterAbilityScoresCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(SetCharacterAbilityScoresCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetCharacterAbilityScores(request, request.Token!);
        return result.ToApiResponse(x => x, "Error setting ability scores");
    }
}
