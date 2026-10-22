using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.Dash;

public class DashCommandHandler : IRequestHandler<DashCommand, ApiResponse<SessionEncounterData>>
{
    private readonly ISessionRpcClient _client;
    public DashCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionEncounterData>> Handle(DashCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.Dash(request, request.Token!);
        return result.ToApiResponse(x => x, "Error dashing");
    }
}
