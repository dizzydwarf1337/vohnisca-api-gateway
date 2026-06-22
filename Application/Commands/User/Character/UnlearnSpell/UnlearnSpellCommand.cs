using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.UnlearnSpell;

public class UnlearnSpellCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid SpellId { get; set; }
}

public class UnlearnSpellCommandHandler : IRequestHandler<UnlearnSpellCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public UnlearnSpellCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(UnlearnSpellCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UnlearnSpell(request, request.Token!);
        return result.ToApiResponse(x => x, "Error unlearning spell");
    }
}
