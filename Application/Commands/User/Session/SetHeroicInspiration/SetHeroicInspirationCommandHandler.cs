using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetHeroicInspiration;

public class SetHeroicInspirationCommandHandler : IRequestHandler<SetHeroicInspirationCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public SetHeroicInspirationCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(SetHeroicInspirationCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetHeroicInspiration(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing Heroic Inspiration");
    }
}
