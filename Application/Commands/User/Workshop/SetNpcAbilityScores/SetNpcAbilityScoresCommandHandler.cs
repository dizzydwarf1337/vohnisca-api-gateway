using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.SetNpcAbilityScores;

public class SetNpcAbilityScoresCommandHandler : IRequestHandler<SetNpcAbilityScoresCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public SetNpcAbilityScoresCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(SetNpcAbilityScoresCommand request, CancellationToken cancellationToken)
        => (await _client.SetNpcAbilityScores(request, request.Token!)).ToApiResponse(x => x, "Error setting the ability scores");
}
