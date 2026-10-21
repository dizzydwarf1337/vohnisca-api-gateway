using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.UpdateCharacterAvatar;

public class UpdateCharacterAvatarCommandHandler : IRequestHandler<UpdateCharacterAvatarCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public UpdateCharacterAvatarCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(UpdateCharacterAvatarCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UpdateCharacterAvatar(request, request.Token!);
        return result.ToApiResponse(x => x, "Error updating character portrait");
    }
}
