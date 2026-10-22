using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.ReleaseCharacterSession;

public class ReleaseCharacterSessionCommandHandler : IRequestHandler<ReleaseCharacterSessionCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public ReleaseCharacterSessionCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(ReleaseCharacterSessionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ReleaseCharacterSession(request, request.Token!);
        return result.ToApiResponse(x => x, "Error releasing the character from the session");
    }
}
