using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetSpent;

public class SetSpentCommandHandler : IRequestHandler<SetSpentCommand, ApiResponse<SessionEncounterData>>
{
    private readonly ISessionRpcClient _client;
    public SetSpentCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionEncounterData>> Handle(SetSpentCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetSpent(request, request.Token!);
        return result.ToApiResponse(x => x, "Error updating the turn");
    }
}
