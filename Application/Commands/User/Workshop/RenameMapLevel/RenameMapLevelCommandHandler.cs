using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.RenameMapLevel;

public class RenameMapLevelCommandHandler : IRequestHandler<RenameMapLevelCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public RenameMapLevelCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(RenameMapLevelCommand request, CancellationToken cancellationToken)
        => (await _client.RenameMapLevel(request, request.Token!)).ToApiResponse(x => x, "Error renaming the level");
}
