using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Workshop.GetWorkshopMapLevel;

public class GetWorkshopMapLevelQueryHandler : IRequestHandler<GetWorkshopMapLevelQuery, ApiResponse<WorkshopMapLevelScene>>
{
    private readonly IWorkshopRpcClient _client;
    public GetWorkshopMapLevelQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<WorkshopMapLevelScene>> Handle(GetWorkshopMapLevelQuery request, CancellationToken cancellationToken)
        => (await _client.GetWorkshopMapLevel(request, request.Token!)).ToApiResponse(x => x, "Error loading the level");
}
