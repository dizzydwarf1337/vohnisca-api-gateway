using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.ReadyAction;

public class ReadyActionCommandHandler : IRequestHandler<ReadyActionCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public ReadyActionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(ReadyActionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ReadyAction(request, request.Token!);
        return result.ToApiResponse(x => x, "Error: ReadyAction");
    }
}
