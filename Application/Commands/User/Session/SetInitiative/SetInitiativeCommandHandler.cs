using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetInitiative;

public class SetInitiativeCommandHandler : IRequestHandler<SetInitiativeCommand, ApiResponse<SessionEncounterData>>
{
    private readonly ISessionRpcClient _client;
    public SetInitiativeCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionEncounterData>> Handle(SetInitiativeCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetInitiative(request, request.Token!);
        return result.ToApiResponse(x => x, "Error setting the initiative");
    }
}
