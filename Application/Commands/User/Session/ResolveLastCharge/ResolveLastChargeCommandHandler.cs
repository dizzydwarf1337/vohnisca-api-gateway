using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.ResolveLastCharge;

public class ResolveLastChargeCommandHandler : IRequestHandler<ResolveLastChargeCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public ResolveLastChargeCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(ResolveLastChargeCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ResolveLastCharge(request, request.Token!);
        return result.ToApiResponse(x => x, "Error deciding the last charge");
    }
}
