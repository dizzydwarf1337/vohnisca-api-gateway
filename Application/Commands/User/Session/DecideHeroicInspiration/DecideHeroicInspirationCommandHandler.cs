using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.DecideHeroicInspiration;

public class DecideHeroicInspirationCommandHandler : IRequestHandler<DecideHeroicInspirationCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public DecideHeroicInspirationCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(DecideHeroicInspirationCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.DecideHeroicInspiration(request, request.Token!);
        return result.ToApiResponse(x => x, "Error deciding on the roll");
    }
}
