using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.AddItemToCharacter;

public class AddItemToCharacterCommandHandler : IRequestHandler<AddItemToCharacterCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public AddItemToCharacterCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(AddItemToCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.AddItemToCharacter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error adding item");
    }
}
