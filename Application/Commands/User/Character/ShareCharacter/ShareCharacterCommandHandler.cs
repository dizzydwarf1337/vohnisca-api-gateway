using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.ShareCharacter;

public class ShareCharacterCommandHandler : IRequestHandler<ShareCharacterCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public ShareCharacterCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(ShareCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ShareCharacter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error sharing character");
    }
}
