using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.CancelTimer;

public class CancelTimerCommandHandler : IRequestHandler<CancelTimerCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public CancelTimerCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(CancelTimerCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.CancelTimer(request, request.Token!);
        return result.ToApiResponse(x => x, "Error dropping the timer");
    }
}
