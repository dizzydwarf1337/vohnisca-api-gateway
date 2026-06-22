using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.LevelUpCharacter;

public class LevelUpCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ClassId { get; set; }
    public int By { get; set; } = 1;
    public List<int>? RolledHitPoints { get; set; }
}

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
