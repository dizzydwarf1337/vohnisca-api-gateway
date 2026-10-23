using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetTimeScale;

public class SetTimeScaleCommandHandler : IRequestHandler<SetTimeScaleCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public SetTimeScaleCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(SetTimeScaleCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetTimeScale(request, request.Token!);
        return result.ToApiResponse(x => x, "Error setting the time's speed");
    }
}
