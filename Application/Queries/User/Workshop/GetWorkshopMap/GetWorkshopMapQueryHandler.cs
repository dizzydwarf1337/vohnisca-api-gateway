using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Workshop.GetWorkshopMap;

public class GetWorkshopMapQueryHandler : IRequestHandler<GetWorkshopMapQuery, ApiResponse<WorkshopMapRow>>
{
    private readonly IWorkshopRpcClient _client;
    public GetWorkshopMapQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<WorkshopMapRow>> Handle(GetWorkshopMapQuery request, CancellationToken cancellationToken)
        => (await _client.GetWorkshopMap(request, request.Token!)).ToApiResponse(x => x, "Error loading the map");
}
