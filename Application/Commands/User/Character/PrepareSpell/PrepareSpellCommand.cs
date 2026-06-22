using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.PrepareSpell;

public class PrepareSpellCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid SpellId { get; set; }
}

public class PrepareSpellCommandHandler : IRequestHandler<PrepareSpellCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public PrepareSpellCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(PrepareSpellCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.PrepareSpell(request, request.Token!);
        return result.ToApiResponse(x => x, "Error preparing spell");
    }
}
