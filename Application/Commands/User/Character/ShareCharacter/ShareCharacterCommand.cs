using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.ShareCharacter;

public class ShareCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Access { get; set; } = string.Empty;
}

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
