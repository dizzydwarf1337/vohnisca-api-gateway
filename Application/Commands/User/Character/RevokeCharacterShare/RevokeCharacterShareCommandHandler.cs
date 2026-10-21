using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.RevokeCharacterShare;

public class RevokeCharacterShareCommandHandler : IRequestHandler<RevokeCharacterShareCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public RevokeCharacterShareCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(RevokeCharacterShareCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RevokeCharacterShare(request, request.Token!);
        return result.ToApiResponse(x => x, "Error revoking character share");
    }
}
