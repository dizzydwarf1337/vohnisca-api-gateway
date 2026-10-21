using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.LearnSpell;

public class LearnSpellCommandHandler : IRequestHandler<LearnSpellCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public LearnSpellCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(LearnSpellCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.LearnSpell(request, request.Token!);
        return result.ToApiResponse(x => x, "Error learning spell");
    }
}
