using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.RenameCharacter;

public class RenameCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class RenameCharacterCommandHandler : IRequestHandler<RenameCharacterCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public RenameCharacterCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(RenameCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RenameCharacter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error renaming character");
    }
}
