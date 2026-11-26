using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.GiveHeroicInspiration;

public class GiveHeroicInspirationCommandHandler : IRequestHandler<GiveHeroicInspirationCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public GiveHeroicInspirationCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(GiveHeroicInspirationCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.GiveHeroicInspiration(request, request.Token!);
        return result.ToApiResponse(x => x, "Error giving Heroic Inspiration");
    }
}
