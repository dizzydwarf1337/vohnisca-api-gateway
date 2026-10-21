using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.UpdateCharacter;

public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public UpdateCharacterCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UpdateCharacter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error updating character");
    }
}
