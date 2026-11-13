using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.Utilize;

public class UtilizeCommandHandler : IRequestHandler<UtilizeCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public UtilizeCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(UtilizeCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.Utilize(request, request.Token!);
        return result.ToApiResponse(x => x, "Error: Utilize");
    }
}
