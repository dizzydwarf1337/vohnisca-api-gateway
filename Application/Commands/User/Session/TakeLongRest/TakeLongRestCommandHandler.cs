using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.TakeLongRest;

public class TakeLongRestCommandHandler : IRequestHandler<TakeLongRestCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public TakeLongRestCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(TakeLongRestCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.TakeLongRest(request, request.Token!);
        return result.ToApiResponse(x => x, "Error resting");
    }
}
