using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.SaveMapLevel;

public class SaveMapLevelCommandHandler : IRequestHandler<SaveMapLevelCommand, ApiResponse<WorkshopMapLevelSaved>>
{
    private readonly IWorkshopRpcClient _client;
    public SaveMapLevelCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<WorkshopMapLevelSaved>> Handle(SaveMapLevelCommand request, CancellationToken cancellationToken)
        => (await _client.SaveMapLevel(request, request.Token!)).ToApiResponse(x => x, "Error saving map level");
}