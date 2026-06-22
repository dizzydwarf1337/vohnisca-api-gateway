using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.AddItemToCharacter;

public class AddItemToCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; } = 1;
}

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
