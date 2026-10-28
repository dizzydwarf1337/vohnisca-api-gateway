using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.RemoveMapLevel;

public class RemoveMapLevelCommandHandler : IRequestHandler<RemoveMapLevelCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public RemoveMapLevelCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(RemoveMapLevelCommand request, CancellationToken cancellationToken)
        => (await _client.RemoveMapLevel(request, request.Token!)).ToApiResponse(x => x, "Error removing the level");
}
