using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.DeleteCharacter;

public class DeleteCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
}

public class DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public DeleteCharacterCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.DeleteCharacter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error deleting character");
    }
}
