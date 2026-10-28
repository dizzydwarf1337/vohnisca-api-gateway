using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.MoveMapLevel;

public class MoveMapLevelCommandHandler : IRequestHandler<MoveMapLevelCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public MoveMapLevelCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(MoveMapLevelCommand request, CancellationToken cancellationToken)
        => (await _client.MoveMapLevel(request, request.Token!)).ToApiResponse(x => x, "Error moving the level");
}
