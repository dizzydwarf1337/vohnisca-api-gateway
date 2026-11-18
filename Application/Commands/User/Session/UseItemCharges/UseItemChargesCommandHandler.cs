using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.UseItemCharges;

public class UseItemChargesCommandHandler : IRequestHandler<UseItemChargesCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public UseItemChargesCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(UseItemChargesCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UseItemCharges(request, request.Token!);
        return result.ToApiResponse(x => x, "Error spending charges");
    }
}
