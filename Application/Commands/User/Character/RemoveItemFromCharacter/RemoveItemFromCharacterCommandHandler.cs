using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.RemoveItemFromCharacter;

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
