using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.UnprepareSpell;

public class UnprepareSpellCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid SpellId { get; set; }
}

public class UnprepareSpellCommandHandler : IRequestHandler<UnprepareSpellCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public UnprepareSpellCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(UnprepareSpellCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UnprepareSpell(request, request.Token!);
        return result.ToApiResponse(x => x, "Error unpreparing spell");
    }
}
