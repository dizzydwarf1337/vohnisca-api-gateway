using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.EndSession;

public class EndSessionCommandHandler : IRequestHandler<EndSessionCommand, ApiResponse<bool>>
{
    private readonly ISessionRpcClient _client;
    public EndSessionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(EndSessionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.EndSession(request, request.Token!);
        return result.ToApiResponse(x => x, "Error ending the session");
    }
}
