using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.LevelUpCharacter;

public class LevelUpCharacterCommandHandler : IRequestHandler<LevelUpCharacterCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public LevelUpCharacterCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(LevelUpCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.LevelUpCharacter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error leveling up character");
    }
}
