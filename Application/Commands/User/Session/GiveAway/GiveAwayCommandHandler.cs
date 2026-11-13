using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.GiveAway;

public class GiveAwayCommandHandler : IRequestHandler<GiveAwayCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public GiveAwayCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(GiveAwayCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.GiveAway(request, request.Token!);
        return result.ToApiResponse(x => x, "Error giving the hider away");
    }
}
