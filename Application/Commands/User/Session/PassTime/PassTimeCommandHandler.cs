using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.PassTime;

public class PassTimeCommandHandler : IRequestHandler<PassTimeCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public PassTimeCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(PassTimeCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.PassTime(request, request.Token!);
        return result.ToApiResponse(x => x, "Error moving the time on");
    }
}
