using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.StartSession;

public class StartSessionCommandHandler : IRequestHandler<StartSessionCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public StartSessionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(StartSessionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.StartSession(request, request.Token!);
        return result.ToApiResponse(x => x, "Error starting the session");
    }
}
