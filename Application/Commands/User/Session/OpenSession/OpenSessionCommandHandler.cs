using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.OpenSession;

public class OpenSessionCommandHandler : IRequestHandler<OpenSessionCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public OpenSessionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(OpenSessionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.OpenSession(request, request.Token!);
        return result.ToApiResponse(x => x, "Error opening the session");
    }
}
