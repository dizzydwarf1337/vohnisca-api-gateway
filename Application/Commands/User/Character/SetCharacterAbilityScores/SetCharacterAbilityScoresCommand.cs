using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.SetCharacterAbilityScores;

public class SetCharacterAbilityScoresCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Dictionary<string, int> AbilityScores { get; set; } = new();
}

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
