using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.RecoverAmmunition;

public class RecoverAmmunitionCommandHandler : IRequestHandler<RecoverAmmunitionCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public RecoverAmmunitionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(RecoverAmmunitionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RecoverAmmunition(request, request.Token!);
        return result.ToApiResponse(x => x, "Error gathering the ammunition");
    }
}
