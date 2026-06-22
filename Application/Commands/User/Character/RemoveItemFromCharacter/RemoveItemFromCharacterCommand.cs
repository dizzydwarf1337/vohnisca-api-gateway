using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.RemoveItemFromCharacter;

public class RemoveItemFromCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; } = 1;
}

public class RemoveItemFromCharacterCommandHandler : IRequestHandler<RemoveItemFromCharacterCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public RemoveItemFromCharacterCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(RemoveItemFromCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RemoveItemFromCharacter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error removing item");
    }
}
